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

namespace GaiApp.ViewModels
{
 
    public class LoginViewModel : EntityViewModel
    {
        private RelayCommand<PasswordBox> _loginCommand;

        public RelayCommand<PasswordBox> LoginCommand => 
            _loginCommand ?? (_loginCommand = new RelayCommand<PasswordBox>(Login));



        public Policeman Policeman { get; set; }

        public LoginViewModel(Entity entity)
        {
            Policeman = entity as Policeman;
        }


        public void Login(PasswordBox box) 
        {
            using(Context context = new Context())
            {
                Policeman loggedPoliceman = context.Policemen
                    .FirstOrDefault(p => p.PolicemanNumber == Policeman.PolicemanNumber &&
                                        p.Password == box.Password);


                if (loggedPoliceman == null)
                {
                    MessageBox.Show("Неправильный номер или пароль");
                }
                else
                {
                    WindowManager.Instance
                        .HideWindow(typeof(LoginWindow));

                    WindowManager.Instance
                        .CreateEntityWindow(typeof(MainWindow), loggedPoliceman);

                    WindowManager.Instance
                        .ShowWindow(typeof(LoginWindow));
                }
            }
        }


    }
}
