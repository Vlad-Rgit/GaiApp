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
using GaiApp.EF.Repositories;

namespace GaiApp.ViewModels.Abstracts
{
    public abstract class BaseViewModel<TEntity>: Bases.NotifyingObject
        where TEntity:Entity     
    {
        private RelayCommand<Type> _closeCommand;
        private RelayCommand _closeCurrentCommand;
        private RelayCommand<Type> _openWindowCommand;
        private RelayCommand<Type> _openArgWindowCommand;

        protected static Repository<TEntity> _repo = new Repository<TEntity>();

        public RelayCommand<Type> CloseCommand =>
            _closeCommand ?? (_closeCommand = new RelayCommand<Type>(CloseWindow));

        public RelayCommand CloseCurrentCommand =>
           _closeCurrentCommand ?? (_closeCurrentCommand = new RelayCommand(CloseCurrentWindow));

        public RelayCommand<Type> OpenWindowCommand =>
            _openWindowCommand ?? (_openWindowCommand = new RelayCommand<Type>(OpenWindow));

        public RelayCommand<Type> OpenArgWindowCommand =>
           _openArgWindowCommand ?? (_openArgWindowCommand = new RelayCommand<Type>(OpenArgWindow));

        protected virtual void CloseWindow(Type windowType)
        {
            WindowManager.Instance
                .CloseWindow(windowType);
        }

        protected virtual void CloseCurrentWindow()
        {
            WindowManager.Instance
                .CloseLastWindow();
        }

        protected virtual void OpenWindow(Type windowType)
        {
            WindowManager.Instance
                .CreateEntityWindow(windowType);
        }

        protected virtual void OpenArgWindow(Type windowType)
        {
            WindowManager.Instance
                 .CreateArgEntityWindow(windowType, null);
        }

    }
}
