using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Interfaces;
using RrepositoryClasses;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Иван Петров";
            int ID = 12;
            Adding added = new Adding();
            ManagerRepository MR = new ManagerRepository();
            MR.Add(new Manager { ManagerID = 17, ManagerName = "Vasi;ii Ermolow" });
            MR.Remove(new Manager { ManagerID = 12, ManagerName = "Igoh John" } );
            MR.Save();
            Console.WriteLine("tuk");           
        }
    }
}
