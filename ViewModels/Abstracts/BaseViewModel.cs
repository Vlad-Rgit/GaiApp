using GaiApp.Commands;
using GaiApp.Models;
using GaiApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.ViewModels.Abstracts
{
    public class BaseViewModel<TEntity>: INotifyPropertyChanged
    {
        private RelayCommand<Type> _closeCommand;
        private RelayCommand<Type> _openWindowCommand;
        private RelayCommand<Type> _openArgWindowCommand;


        public RelayCommand<Type> CloseCommand =>
            _closeCommand ?? (_closeCommand = new RelayCommand<Type>(CloseWindow));

        public RelayCommand<Type> OpenWindowCommand =>
            _openWindowCommand ?? (_openWindowCommand = new RelayCommand<Type>(OpenWindow));

        public RelayCommand<Type> OpenArgWindowCommand =>
           _openArgWindowCommand ?? (_openArgWindowCommand = new RelayCommand<Type>(CloseWindow));


        public event PropertyChangedEventHandler PropertyChanged;

        protected void CloseWindow(Type windowType)
        {
            WindowManager.Instance
                .CloseWindow(windowType);
        }

        protected void OpenWindow(Type windowType)
        {
            WindowManager.Instance
                .CreateEntityWindow(windowType);
        }

        protected void OpenArgWindow(Type windowType, Entity entity)
        {
            WindowManager.Instance
                .CreateEntityWindow(windowType, entity);
        }

        protected void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
