using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GaiApp.Models;
using GaiApp.ViewModels;
using GaiApp.Windows;

namespace GaiApp.Services
{
    public sealed class WindowManager
    {

        private Dictionary<string, EntityWindow> _entityWindows = new Dictionary<string, EntityWindow>();

        public static WindowManager Instance { get; set; } = new WindowManager();
     
          

        private WindowManager() { }


        public LoginWindow CreateStartWindow()
        {
            LoginWindow loginWindow = new LoginWindow();

            loginWindow.ViewModel = (EntityViewModel)
               Activator.CreateInstance(loginWindow.ViewModelType, new Policeman());

            _entityWindows[typeof(LoginWindow).FullName] = loginWindow;

            return loginWindow;
        }

        public void CreateEntityWindow(Type windowType, Entity entity, bool isDialog = true)
        {
            EntityWindow win;

            if (_entityWindows.ContainsKey(windowType.FullName))
            {
                win = _entityWindows[windowType.FullName];
            }
            else
            {
                win = (EntityWindow)
                   Activator.CreateInstance(windowType);

                win.ViewModel = (EntityViewModel)
                    Activator.CreateInstance(win.ViewModelType, entity);

                _entityWindows[windowType.FullName] = win;
            }

            if (isDialog)
                win.ShowDialog();
            else
                win.Show();
        }

        public void ShowWindow(Type windowType)
        {
            _entityWindows[windowType.FullName].Show();
        }

        public void ShowDialogWindow(Type windowType)
        {
            _entityWindows[windowType.FullName].ShowDialog();
        }

        public void HideWindow(Type windowType)
        {
            _entityWindows[windowType.FullName].Hide();
        }

        public void CloseWindow(Type windowType)
        {
            _entityWindows[windowType.FullName].Close();
            _entityWindows.Remove(windowType.FullName);
        }
    }
}
