using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;


namespace DAL.Classes
{
    /*
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private SampleDbEntities entities = null;
        IObjectSet<T> _objectSet;

        protected DBConnect managersContext;

        public GenericRepository(SampleDbEntities _entities)
        {
            entities = _entities;
            _objectSet = entities.CreateObjectSet<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public void Add(T entity)
        {
            _objectSet.AddObject(entity);
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.DeleteObject(entity);
        }      
    }
    */
}
