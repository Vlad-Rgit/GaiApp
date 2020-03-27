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

        private string _searchString;
        private ContainerManager _containerManager;
        private SearchProperty _selectedProperty;

        protected readonly Repository<TEntity> _repo;

        public TEntity SelectedEntity { get; set; }
        public List<SearchProperty> SearchProperties { get; set; }
            = new List<SearchProperty>();

        public SearchProperty SelectedProperty
        {
            get => _selectedProperty;
            set
            {
                _selectedProperty = value;
                OnPropertyChanged();
            }
        }

        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                Search();
            }
        }
      
        public ObservableCollection<TEntity> Entities { get; set; }

        public ListViewModel()
        {
            _repo = new Repository<TEntity>();
            _containerManager = new ContainerManager();

            Entities = new ObservableCollection<TEntity>(_repo.GetAll());
            foreach(var p in typeof(TEntity).GetProperties())
            {
                var attribute = p.GetCustomAttribute(typeof(SearchPropertyAttribute));

                if (attribute != null)
                {
                   SearchProperty searchProperty = 
                        _containerManager.RegisterProperty(p);

                   SearchProperties.Add(searchProperty);
                }
            }
        }



        public virtual void Search()
        {
            Entities.Clear();

            foreach (var a in _repo.GetAll())
            {
                if (SelectedProperty
                    .PropertyInfo.GetValue(a)
                    .ToString().Contains(SearchString))
                {
                    Entities.Add(a);
                }
            }
        }
    }
}
