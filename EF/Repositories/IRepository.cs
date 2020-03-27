using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;

namespace GaiApp.EF.Repositories
{
    interface IRepository<T> : IDisposable
        where T : Entity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object key);
        T Get(object key);
        IList<T> GetAll();
        int SaveChanges();
    }
}
