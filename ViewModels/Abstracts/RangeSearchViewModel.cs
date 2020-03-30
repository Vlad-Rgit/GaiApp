using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Attributes;
using GaiApp.Models;
using GaiApp.SearchProperties;

namespace GaiApp.ViewModels.Abstracts
{
    public class RangeSearchViewModel<TEntity> : SearchViewModel<TEntity>
        where TEntity: Entity
    {

        private dynamic _beginValue;
        private dynamic _endValue;

        private RangeProperty _selectedRangeProperty;

        public dynamic BeginValue
        {
            get => _beginValue;
            set
            {
                _beginValue = value;
                Search();
            }
        }
        public dynamic EndValue
        {
            get => _endValue;
            set
            {
                _endValue = value;
                Search();
            }
        }

        public List<RangeProperty> RangeProperties { get; set; }
                    = new List<RangeProperty>();

        public RangeProperty SelectedRangeProperty
        {
            get => _selectedRangeProperty;
            set
            {
                _selectedRangeProperty = value;
                OnPropertyChanged();
            }
        }

        public RangeSearchViewModel()
        {
            foreach (var p in typeof(TEntity).GetProperties())
            {
                var attribute = p.GetCustomAttribute(typeof(RangePropertyAttribute));

                if (attribute != null)
                {
                    RangeProperty searchProperty =
                         _containerManager.RegisterRangeProperty(p);

                    RangeProperties.Add(searchProperty);
                }
            }

            SelectedRangeProperty =
                RangeProperties[0];
        }

        public override void Search()
        {
            base.Search();

            foreach(var a in Entities.ToList())
            {
                if (SelectedRangeProperty.GetValue(a) < BeginValue)
                    Entities.Remove(a);

                if (SelectedRangeProperty.GetValue(a) > EndValue)
                    Entities.Remove(a);
            }
        }
    }
}
