using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;

namespace GaiApp.ViewModels.Abstracts
{
    public abstract class AddViewModel<TEntity> : SingleViewModel<TEntity>
        where TEntity: Entity
    {
        private bool _isToUpdate;

        protected AddViewModel(Entity entity) : base(entity)
        {
            _isToUpdate = entity == null ? true : false;  
        }

        public abstract void Save();
    }
}
