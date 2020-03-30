using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GaiApp.Models;
using GaiApp.ViewModels.Abstracts;

namespace GaiApp.Windows.Abstracts
{
    public class EntityWindow<TViewModel, TEntity> : Window
        where TEntity : Entity
        where TViewModel : BaseViewModel<TEntity>
    {
        private TViewModel _viewModel;

        public Type ViewModelType { get; set; }

        public TViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public void SetViewModel(object viewModel)
        {
            ViewModel = (TViewModel)viewModel;
        }

        protected EntityWindow()
        {
            ViewModelType = typeof(TViewModel);
        }


        protected void DragMoveEvent(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
