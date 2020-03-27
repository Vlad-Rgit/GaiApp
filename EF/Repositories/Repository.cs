using GaiApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace GaiApp.EF.Repositories
{
    public class Repository<T> : IRepository<T>
        where T: Entity
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _set;

        public Repository()
        {
            _context = new Context();
            _set = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(object key)
        {
            T entity = _set.Find(key);

            if (entity == null)
                throw new ApplicationException("The entity does not exist");

            _context.Entry(entity).State = EntityState.Deleted;
        } 

        public T Get(object key)
        {
            return _set.Find(key);
        }

        public IList<T> GetAll()
        {
            return _set.ToList();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            try
            {
               return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
