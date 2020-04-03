using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Attributes;
using GaiApp.Models;
using GaiApp.SearchProperties;
using GaiApp.Services;

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
                Search(this, new EventArgs());
            }
        }
        public dynamic EndValue
        {
            get => _endValue;
            set
            {
                _endValue = value;
                Search(this, new EventArgs());
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
                         ContainerManager.RegisterRangeProperty(p);

                    RangeProperties.Add(searchProperty);
                }
            }

            SelectedRangeProperty =
                RangeProperties[0];
        }

        public override void Search(object sender, EventArgs args)
        {
            base.Search(sender, args);

            foreach(var a in Entities.ToList())
            {
                if (SelectedRangeProperty.GetDynamicValue(a) < BeginValue)
                    Entities.Remove(a);

                if (SelectedRangeProperty.GetDynamicValue(a) > EndValue)
                    Entities.Remove(a);
            }
        }
    }
}
