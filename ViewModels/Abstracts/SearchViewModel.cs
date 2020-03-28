using GaiApp.Attributes;
using GaiApp.Models;
using GaiApp.SearchProperties;
using GaiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.ViewModels.Abstracts
{
    public class SearchViewModel<TEntity> : ListViewModel<TEntity>
        where TEntity : Entity
    {
        private string _searchString;   
        private SearchProperty _selectedProperty;

        protected ContainerManager _containerManager;
        
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

        public SearchViewModel()
        {
            _containerManager = new ContainerManager();

        
            foreach (var p in typeof(TEntity).GetProperties())
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
