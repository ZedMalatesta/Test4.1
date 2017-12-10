using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Иван Петров";
            int ID = 12;
            Adding added = new Adding();
            added.AddNewManager(16, "Igoh John");
            Console.WriteLine("piska");           
        }
    }
}
