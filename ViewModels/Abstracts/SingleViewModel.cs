using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.Commands;
using GaiApp.Services;

namespace GaiApp.ViewModels.Abstracts
{
    public abstract class SingleViewModel<TEntity> : BaseViewModel<TEntity>
        where TEntity: Entity
    {
        public TEntity Entity { get; set; }

        protected SingleViewModel(Entity entity)
        {
            Entity = (TEntity)entity;
        }     
    }
}
