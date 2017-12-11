using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
