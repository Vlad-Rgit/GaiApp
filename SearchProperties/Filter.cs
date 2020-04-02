using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Arguments;

namespace GaiApp.SearchProperties
{
    public class Filter
    {
        private string _searchString;

        public delegate void FilterHandler(object sender, FilterArgs args);

        public string SearchString
        {
            get => _searchString;
            set
            {
                string oldValue = _searchString;
                _searchString = value;
                SearchStringUpdated?.Invoke(this, new FilterArgs(oldValue, _searchString));
            }
        }

        public SearchProperty SearchProperty { get; set; }

        public event FilterHandler SearchStringUpdated;
    }

    
}
