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
using GaiApp.Commands;

namespace GaiApp.ViewModels.Abstracts
{
    public class ListViewModel<TEntity> : BaseViewModel<TEntity>
        where TEntity: Entity
    {

        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));


        public ObservableCollection<TEntity> Entities { get; set; }
        public TEntity SelectedEntity { get; set; }

        public ListViewModel()
        {
            Entities = new ObservableCollection<TEntity>(_repo.GetAll());
        }

        protected override void OpenArgWindow(Type windowType)
        {
            WindowManager.Instance
                 .CreateArgEntityWindow(windowType, SelectedEntity);

            Entities.Clear();

            foreach (var e in _repo.GetAllOfType<TEntity>())
                Entities.Add(e);
        }

        protected void Delete()
        {
            _repo.Delete(SelectedEntity);
            _repo.SaveChanges();

            Entities.Remove(SelectedEntity);
        }
    }
}
