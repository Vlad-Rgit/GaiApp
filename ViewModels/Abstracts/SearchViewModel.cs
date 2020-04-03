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
using GaiApp.Collectons;

namespace GaiApp.ViewModels.Abstracts
{
    public class SearchViewModel<TEntity> : ListViewModel<TEntity>
        where TEntity : Entity
    {
        private RelayCommand _addFilterCommand;
        private RelayCommand<Filter> _deleteFilterCommand;
        
        public ObservableCollection<SingleProperty> SearchProperties { get; set; }
            = new ObservableCollection<SingleProperty>();

        public FilterCollection Filters { get; set; } = new FilterCollection();


        public RelayCommand AddFilterCommand =>
            _addFilterCommand ?? (_addFilterCommand = new RelayCommand(AddFilter));

        public RelayCommand<Filter> DeleteFilterCommand =>
            _deleteFilterCommand ?? (_deleteFilterCommand = new RelayCommand<Filter>(DeleteFilter));


        public SearchViewModel()
        {
        
            foreach(var p in
                PropertySearcher.GetSearchProperties(typeof(TEntity)))
            {
                SingleProperty property = ContainerManager.RegisterProperty(p);
                SearchProperties.Add(property);
            }
        }

        public virtual void AddFilter()
        {
            Filter filter = new Filter();
            filter.FilterExecute += Search;   
            Filters.Add(filter);
        }

        public virtual void DeleteFilter(Filter filter)
        {
            Filters.Remove(filter);
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
                Type ownerType = f.SingleProperty.PropertyInfo.DeclaringType;

                if (typeof(TEntity) == ownerType)
                    isNested = false;

                foreach (var a in _repo.GetAll())
                {
                    if (isNested)
                        owner =
                            PropertySearcher.GetNestedEntity(a, ownerType);
                    else
                        owner = a;

                    if (!f.IsContainsSearchString(owner))
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
