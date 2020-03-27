using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Commands;
using GaiApp.Models;
using GaiApp.EF;
using GaiApp.Services;
using System.Windows;
using GaiApp.Windows;
using System.Windows.Controls;
using System.Security;
using GaiApp.EF.Repositories;
using GaiApp.ViewModels.Abstracts;

namespace GaiApp.ViewModels
{
 
    public class LoginViewModel : SingleViewModel<Policeman>
    {
        private RelayCommand<PasswordBox> _loginCommand;

        public RelayCommand<PasswordBox> LoginCommand => 
            _loginCommand ?? (_loginCommand = new RelayCommand<PasswordBox>(Login));



        public LoginViewModel(Entity entity) : base(entity)
        {
         
        }


        public void Login(PasswordBox box) 
        {         
            using(PolicemanRepo repo = new PolicemanRepo())
            {
                Policeman loggedPoliceman = 
                    repo.GetPoliceman(Entity.PolicemanNumber, box.Password);

                if (loggedPoliceman == null)
                {
                    MessageBox.Show("Неправильный номер или пароль");
                }
                else
                {
                    WindowManager.Instance
                        .HideWindow<LoginWindow>();

                    WindowManager.Instance
                        .CreateEntityWindow<MainWindow>(loggedPoliceman);

                    WindowManager.Instance
                        .ShowWindow<LoginWindow>();
                }
            }
        }


    }
}
