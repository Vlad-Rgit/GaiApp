using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using GaiApp.ViewModels.Abstracts;
using GaiApp.Converters;
using GaiApp.SearchProperties;

namespace GaiApp.Services
{
    public class ContainerManager
    {
        private PropertyInfo _searchString;
        private object _viewModel;

        private ToStringConverter _converter
            = new ToStringConverter();

        public SearchProperty RegisterProperty(PropertyInfo propertyInfo)
        {
            SearchProperty searchProperty =
                new SearchProperty() { PropertyInfo = propertyInfo };


            Binding binding = new Binding();
            binding.Path = new PropertyPath("SearchString");
            binding.Mode = BindingMode.OneWayToSource;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            switch (propertyInfo.PropertyType.Name)
            {
                case nameof(DateTime):
                    searchProperty.Control = new DatePicker();
                    binding.Converter = _converter;
                    searchProperty.Control
                        .SetBinding(DatePicker.SelectedDateProperty, binding);
                    break;
                default:
                    searchProperty.Control = new TextBox();                   
                    searchProperty.Control
                        .SetBinding(TextBox.TextProperty, binding);

                    break;
            }

            return searchProperty;
        }

        public RangeProperty RegisterRangeProperty(PropertyInfo propertyInfo)
        {
            RangeProperty searchProperty =
                new RangeProperty() { PropertyInfo = propertyInfo };


            Binding beginBinding = new Binding();
            beginBinding.Path = new PropertyPath("BeginValue");
            beginBinding.Mode = BindingMode.OneWayToSource;
            beginBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;


            Binding endBinding = new Binding();
            endBinding.Path = new PropertyPath("EndValue");
            endBinding.Mode = BindingMode.OneWayToSource;
            endBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            switch (propertyInfo.PropertyType.Name)
            {
                case nameof(DateTime):
                    searchProperty.BeginControl = new DatePicker();
                    searchProperty.EndControl = new DatePicker();
                    searchProperty.BeginControl
                             .SetBinding(DatePicker.SelectedDateProperty, beginBinding);
                    searchProperty.EndControl
                             .SetBinding(DatePicker.SelectedDateProperty, endBinding);

                    break;
                default:
                    searchProperty.BeginControl = new TextBox();
                    searchProperty.EndControl = new TextBox();
                    searchProperty.BeginControl
                             .SetBinding(TextBox.TextProperty, beginBinding);
                    searchProperty.EndControl
                             .SetBinding(TextBox.TextProperty, endBinding);

                    break;
            }



            return searchProperty;
        }
    }
}
