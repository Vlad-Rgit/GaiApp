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
            entity.IsDeleted = true;
            Update(entity);
        }

        public void Delete(object key)
        {
            T entity = _set.Find(key);

            if (entity == null)
                throw new ApplicationException("The entity does not exist");

            entity.IsDeleted = true;
            Update(entity);
        } 

        public T Get(object key)
        {
            return _set.Find(key);
        }

        public TEntity GetOfType<TEntity>(params object[] keys)
            where TEntity: Entity
        {
            return _context.Set<TEntity>().Find(keys);
        }

        public IList<T> GetAll()
        {
            return _set.Where(e=>e.IsDeleted==false).ToList();
        }

        public IList<TEntity> GetAllOfType<TEntity>() where TEntity : Entity
        {
            return _context.Set<TEntity>().Where(e => e.IsDeleted == false).ToList();
        }

        public IList<Entity> GetAllOfType(Type entityType)
        {
            return _context.Set(entityType).Cast<Entity>().Where(e => e.IsDeleted == false).ToList();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Reload(T entity)
        {
            _context.Entry(entity).Reload();
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
