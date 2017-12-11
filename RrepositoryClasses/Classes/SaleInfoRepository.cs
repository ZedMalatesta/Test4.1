using DAL.Interfaces;
using RrepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class SaleInfoRepository : IRepository<RrepositoryClasses.SaleInfo>
    {
        protected SaleDBEntities _saleInfoContext;

        public SaleInfoRepository()
        {
            _saleInfoContext = new SaleDBEntities();
        }

        public void Add(SaleInfo entity)
        {
            _saleInfoContext.SaleInfo.Add(entity);
        }

        public IEnumerable<SaleInfo> GetAll()
        {
            return _saleInfoContext.SaleInfo;
        }

        public SaleInfo GetById(int id)
        {
            return _saleInfoContext.SaleInfo.FirstOrDefault(x => x.ManagerID == id);
        }

        public void Remove(SaleInfo entity)
        {
            var item = _saleInfoContext.SaleInfo.FirstOrDefault(x => x.ManagerID == entity.ManagerID);
            if (item != null)
            {
                _saleInfoContext.SaleInfo.Remove(item);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            };
        }

        public void Update(SaleInfo entity)
        {
            var item = _saleInfoContext.SaleInfo.FirstOrDefault(x => x.ManagerID == entity.ManagerID);
            if (item != null)
            {
                item.ClientName = entity.ClientName;
                item.Date = entity.Date;
                item.Product = entity.Product;
                item.Cost = entity.Cost;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            };
        }

        public void Save()
        {
            _saleInfoContext.SaveChanges();
        }

        public void Dispose()
        {
            _saleInfoContext.Dispose();
        }
    }
}
