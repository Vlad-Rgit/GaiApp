using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.Commands;
using GaiApp.Services;

namespace GaiApp.ViewModels
{
    public abstract class EntityViewModel
    {
        private RelayCommand<Type> _closeCommand;

        public RelayCommand<Type> CloseCommand =>
            _closeCommand ?? (_closeCommand = new RelayCommand<Type>(CloseWindow));

        protected void CloseWindow(Type windowType)
        {
            WindowManager.Instance
                .CloseWindow(windowType);
        }
    }
}
