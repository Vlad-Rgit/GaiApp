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
    public static class ContainerManager
    { 

        private readonly struct ContainerInfo
        {
            public ContainerInfo(Type controlType, Binding binding, DependencyProperty bindedProperty)
                => (ControlType, Binding, BindedProperty) = (controlType, binding, bindedProperty);

            public Type ControlType { get; }
            public Binding Binding { get; }
            public DependencyProperty BindedProperty { get; }
        }

        private static ToStringConverter _converter
            = new ToStringConverter();

        private static Dictionary<SingleProperty, ContainerInfo> _containerInfos =
            new Dictionary<SingleProperty, ContainerInfo>();

        public static SingleProperty RegisterProperty(PropertyInfo propertyInfo)
        {
            SingleProperty searchProperty =
                new SingleProperty() { PropertyInfo = propertyInfo };

            Type controlType;
            DependencyProperty bindedProperty;
  
            Binding binding = new Binding();
            binding.Path = new PropertyPath("SearchString");
            binding.Mode = BindingMode.OneWayToSource;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            switch (propertyInfo.PropertyType.Name)
            {
                case nameof(DateTime):
                    controlType = typeof(DatePicker);
                    binding.Converter = _converter;
                    bindedProperty = DatePicker.SelectedDateProperty;
                    break;
                default:
                    controlType = typeof(TextBox);
                    bindedProperty = TextBox.TextProperty;
                    break;
            }

            ContainerInfo info =
                new ContainerInfo(controlType, binding, bindedProperty);

            _containerInfos[searchProperty] = info;

            return searchProperty;
        }

        public static Control CreateSingleContainer(SingleProperty property)
        {
            ContainerInfo info = _containerInfos[property];
            Control control =(Control) Activator.CreateInstance(info.ControlType);
            control.SetBinding(info.BindedProperty, info.Binding);
            return control;
        }

        public static RangeProperty RegisterRangeProperty(PropertyInfo propertyInfo)
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
