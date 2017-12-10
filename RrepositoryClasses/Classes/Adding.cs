using DAL.Models;
using RrepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Classes
{
    public class Adding
    {
        public void AddNewManager(int managerID, string managerName)
        {
            SEDBdbEntities context = new SEDBdbEntities();
            DAL.Manager customer = new DAL.Manager
            {
                ManagerName = managerName,
                ManagerID = managerID
            };

            // Добавить в DbSet
            context.Manager.Add(customer);

            // Сохранить изменения в базе данных
            context.SaveChanges(); 
        }
        /*ManagerSaleInfoContext context = new ManagerSaleInfoContext();

        // Создать нового покупателя
        Manager customer = new Manager
        {
            ManagerName = managerName,
            ManagerID = managerID
        };

        // Добавить в DbSet
        context.Managers.Add(customer);

        // Сохранить изменения в базе данных
        context.SaveChanges();*/
    }
}
