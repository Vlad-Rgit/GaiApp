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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? dateTime = ((DatePicker)sender).SelectedDate;

            _searchString.SetValue(_viewModel, dateTime.Value.ToString());
        }
    }
}
