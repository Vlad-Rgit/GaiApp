using GaiApp.Attributes;
using GaiApp.Models;
using GaiApp.SearchProperties;
using GaiApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Commands;

namespace GaiApp.ViewModels.Abstracts
{
    public class SearchViewModel<TEntity> : ListViewModel<TEntity>
        where TEntity : Entity
    {
        private RelayCommand _addFilterCommand;


        protected ContainerManager _containerManager;
        
        public List<SingleProperty> SearchProperties { get; set; }
            = new List<SingleProperty>();

        public ObservableCollection<Filter> Filters { get; set; }
        = new ObservableCollection<Filter>();


        public RelayCommand AddFilterCommand =>
            _addFilterCommand ?? (_addFilterCommand = new RelayCommand(AddFilter));

    


        public SearchViewModel()
        {
            _containerManager = new ContainerManager();

            foreach(var p in
                PropertySearcher.GetSearchProperties(typeof(TEntity)))
            {
                SingleProperty property = _containerManager.RegisterProperty(p);
                SearchProperties.Add(property);
            }
        }

        public virtual void AddFilter()
        {
            Filter filter = new Filter();
            filter.SearchStringUpdated += Search;
            filter.SearchProperty = SearchProperties[0];
            Filters.Add(filter);
        }

        public virtual void Search(object sender, EventArgs args)
        {
            LinkedList<TEntity> temp =
                new LinkedList<TEntity>(_repo.GetAll());

            Entities.Clear();

            foreach (var f in Filters)
            {
                bool isNested = true;

                object owner;
                Type ownerType = f.SearchProperty.PropertyInfo.DeclaringType;

                if (typeof(TEntity) == ownerType)
                    isNested = false;

                foreach (var a in _repo.GetAll())
                {
                    if (isNested)
                        owner =
                            PropertySearcher.GetNestedEntity(a, ownerType);
                    else
                        owner = a;

                    if (!f.SearchProperty.GetStringValue(owner)
                        .Contains(f.SearchString))
                    {
                        temp.Remove(a);
                    }
                }
            }

            foreach (var e in temp)
                Entities.Add(e);
        }
    }
}
