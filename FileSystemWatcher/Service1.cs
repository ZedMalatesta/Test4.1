using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystemWatcher
{
    public partial class Service1 : ServiceBase
    {
        string WatchPath = ConfigurationManager.AppSettings["WatchPath"];

        public Service1()
        {
            InitializeComponent();
            fileSystemWatcher.Created += fileSystemWatcher_Created;
            fileSystemWatcher.Filter = "*.csv"; 
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
                Thread.Sleep(10000);
                if (CheckFileExistance(WatchPath, e.Name))
                {
                    CreateTextFile(WatchPath, e.Name);
                    ReadInfo(WatchPath, e.Name);
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

        private void ReadInfo(string FullPath, string FileName)
        {
            Parser pars = new Parser();
            string Destination = "C:\\newProjects\\Project4\\FileSystemWatcher\\txtfile.txt";
            StreamWriter SW;          
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txt_" + ".txt")))
            {
                SW = File.CreateText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txt_" + ".txt"));
                SW.Close();
            }
            using (SW = new StreamWriter(Destination, true, Encoding.GetEncoding("windows-1251")))
            {
                var records = pars.ParseData(FullPath+"\\"+FileName);
                SW.WriteLine("File: " + string.Join(",", records.Select(x => x.ToString())));
                SW.Close();
            }
        }

        public static void Create_ServiceStoptextfile()
        {
            string Destination = "C:\\newProjects\\Project4\\FileSystemWatcher\\FileSystemWatcherLog";
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
