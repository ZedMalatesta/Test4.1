using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Reflection;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        string WatchPath = ConfigurationManager.AppSettings["WatchPath"];
        public Service1()
        {
            InitializeComponent();
            fileSystemWatcher.Created += fileSystemWatcher_Created;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                fileSystemWatcher.Path = WatchPath;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override void OnStop()
        {
            try
            {
                Create_ServiceStoptextfile();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                Thread.Sleep(70000); 
                if (CheckFileExistance(WatchPath, e.Name))
                {
                    CreateTextFile(WatchPath, e.Name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckFileExistance(string FullPath, string FileName)
        {
            // Get the subdirectories for the specified directory.'  
            bool IsFileExist = false;
            DirectoryInfo dir = new DirectoryInfo(FullPath);
            if (!dir.Exists)
                IsFileExist = false;
            else
            {
                string FileFullPath = Path.Combine(FullPath, FileName);
                if (File.Exists(FileFullPath))
                    IsFileExist = true;
            }
            return IsFileExist;
        }

        private void CreateTextFile(string FullPath, string FileName)
        {
            StreamWriter SW;
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")))
            {
                SW = File.CreateText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"));
                SW.Close();
            }
            using (SW = File.AppendText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")))
            {
                SW.WriteLine("File Created with Name: " + FileName + " at this location: " + FullPath);
                SW.Close();
            }
        }

        public static void Create_ServiceStoptextfile()
        {
            string Destination = "C:\\Users\\Zedd\\Documents\\Visual Studio 2015\\Projects\\Project4\\FileWatcherLog";
            StreamWriter SW;
            if (Directory.Exists(Destination))
            {
                Destination = System.IO.Path.Combine(Destination, "txtServiceStop_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!File.Exists(Destination))
                {
                    SW = File.CreateText(Destination);
                    SW.Close();
                }
            }
            using (SW = File.AppendText(Destination))
            {
                SW.Write("\r\n\n");
                SW.WriteLine("Service Stopped at: " + DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));
                SW.Close();
            }
        }
    }
}
