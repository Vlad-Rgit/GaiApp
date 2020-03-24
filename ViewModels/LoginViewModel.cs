using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Commands;
using GaiApp.Models;
using GaiApp.EF;
using GaiApp.Services;

namespace GaiApp.ViewModels
{
 
    public class LoginViewModel
    {
        private RelayCommand _loginCommand;

        public RelayCommand LoginCommand => 
            _loginCommand ?? (_loginCommand = new RelayCommand(Login));



        public Policeman Policeman { get; set; } = new Policeman();

        public LoginViewModel() { }


        public void Login()
        {
            using(Context context = new Context())
            {
                Policeman loggedPoliceman = context.Policemen.
                    FirstOrDefault(p => p.PolicemanNumber == Policeman.PolicemanNumber);

                if (loggedPoliceman != null)
                {
                    WindowManager.OpenMainMenu(loggedPoliceman);
                }
            }
        }

    }
}
