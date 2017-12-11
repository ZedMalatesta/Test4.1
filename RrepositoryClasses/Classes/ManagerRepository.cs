using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using RrepositoryClasses;
using System.Data.Entity.Core.Objects;
using DAL.Interfaces;
using System.Linq.Expressions;

namespace DAL.Classes
{    
    public class ManagerRepository : IRepository<RrepositoryClasses.Manager>
    {
        protected RrepositoryClasses.SaleDBEntities _managersContext;

        public ManagerRepository()
        {
            _managersContext = new SaleDBEntities();
        }

        public void Add(Manager entity)
        {
            _managersContext.Manager.Add(entity);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _managersContext.Manager;
        }

        public Manager GetById(int id)
        {
            return _managersContext.Manager.FirstOrDefault(x => x.ManagerID == id);
        }

        public void Remove(RrepositoryClasses.Manager entity)
        {
                var item = _managersContext.Manager.FirstOrDefault(x => x.ManagerID == entity.ManagerID);
                if (item != null)
                {
                    _managersContext.Manager.Remove(item);
                }
                else
                {
                    throw new ArgumentException("Incorrect argument!!!");
                };
        }

        public void Update(Manager entity)
        {
            var item = _managersContext.Manager.FirstOrDefault(x => x.ManagerID == entity.ManagerID);
            if (item != null)
            {
                item.ManagerName = entity.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            };
        }

        public void Save()
        {
            _managersContext.SaveChanges();
        }

        public void Dispose()
        {
            _managersContext.Dispose();
        }
    }
}
