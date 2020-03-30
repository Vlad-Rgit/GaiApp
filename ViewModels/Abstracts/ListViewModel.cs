using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GaiApp.EF.Repositories;
using GaiApp.Models;
using GaiApp.Attributes;
using GaiApp.Services;
using GaiApp.SearchProperties;
using System.ComponentModel;

namespace GaiApp.ViewModels.Abstracts
{
    public class ListViewModel<TEntity> : BaseViewModel<TEntity>
        where TEntity: Entity
    {    
        public ObservableCollection<TEntity> Entities { get; set; }
        public TEntity SelectedEntity { get; set; }

        public ListViewModel()
        {
            _repo = new Repository<TEntity>();
            Entities = new ObservableCollection<TEntity>(_repo.GetAll());
        }

        protected override void OpenArgWindow(Type windowType)
        {
            WindowManager.Instance
                 .CreateEntityWindow(windowType, SelectedEntity);
        }
    }
}
