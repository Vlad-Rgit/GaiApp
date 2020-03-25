using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GaiApp.Models;
using GaiApp.ViewModels;

namespace GaiApp.Windows
{
    public class EntityWindow : Window
    {
        private EntityViewModel _viewModel;

        public Type ViewModelType { get; set; }

        public EntityViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }


        protected EntityWindow(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
