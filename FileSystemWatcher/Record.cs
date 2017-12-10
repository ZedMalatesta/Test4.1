using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcher
{
    class Record
    {
        public string ManagerName { get; private set; }
        public string SaleDate { get; private set; }
        public string ClientName { get; private set; }
        public string Product { get; private set; }
        public string Cost { get; private set; }

        public Record(string managerName, string saleDate, string clientName, string product, string cost)
        {
            ManagerName = managerName;
            SaleDate = saleDate;
            ClientName = clientName;
            Product = product;
            Cost = cost;
        }

        public override string ToString()
        {
            return ManagerName+SaleDate+ClientName+Product+Cost;
        }
    }
}
