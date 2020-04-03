using GaiApp.Arguments;
using GaiApp.Services;
using System;

namespace GaiApp.SearchProperties
{
    public class Filter : Bases.NotifyingObject, IDisposable
    {
        private string _searchString;
        private SingleProperty _singleProperty;
        public delegate void FilterHandler(object sender, FilterArgs args);

        public string SearchString
        {
            get => _searchString;
            set
            {
                string oldValue = _searchString;
                _searchString = value;
                FilterExecute?.Invoke(this, new FilterArgs(oldValue, _searchString));
            }
        }

        public SingleProperty SingleProperty
        {
            get => _singleProperty;
            set
            {
                _singleProperty = value;
                _singleProperty.Control =
                    ContainerManager.CreateSingleContainer(_singleProperty);
                OnPropertyChanged();
            }
        }
               


        public event FilterHandler FilterExecute;

        public bool IsContainsSearchString(object propertyOwner)
            => SingleProperty
                .GetStringValue(propertyOwner)
                .Contains(SearchString);

        public void Dispose()
        {
            FilterExecute?.Invoke(this, new FilterArgs("", SearchString));
        }
    }   
}
