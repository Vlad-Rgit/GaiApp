using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GaiApp.Models;
using GaiApp.ViewModels;
using GaiApp.Windows;
using GaiApp.ViewModels.Abstracts;
using GaiApp.Windows.Abstracts;
using System.Reflection;

namespace GaiApp.Services
{
    public sealed class WindowManager
    {

        private Dictionary<string, Window> _entityWindows = new Dictionary<string, Window>();

        public static WindowManager Instance { get; set; } = new WindowManager();
          
        private WindowManager() { }

        public LoginWindow CreateStartWindow()
        {
            LoginWindow loginWindow = new LoginWindow();

            loginWindow.SetViewModel
                (Activator.CreateInstance(loginWindow.ViewModelType, new Policeman()));
            

            _entityWindows[typeof(LoginWindow).FullName] = loginWindow;

            return loginWindow;
        }

        public void CreateEntityWindow<TWindow> (Entity entity = null, bool isDialog = true)
            where TWindow : Window, new()

        {
            TWindow win;

            Type winType = typeof(TWindow);

            if (_entityWindows.ContainsKey(winType.FullName))
            {
                win = (TWindow)_entityWindows[winType.FullName];
            }
            else
            {
                win = new TWindow();

                MethodInfo setViewModel = winType.GetMethod("SetViewModel");

                if (entity == null)
                {
                    Type viewModelType = (Type)winType
                           .GetProperty("ViewModelType").GetValue(win);

                    setViewModel.Invoke(win,
                        new object[] {
                    Activator.CreateInstance(viewModelType)});
                }
                else
                {
                    Type viewModelType = (Type)winType
                         .GetProperty("ViewModelType").GetValue(win);

                    setViewModel.Invoke(win,
                        new object[] {
                    Activator.CreateInstance(viewModelType, entity)});
                }

                _entityWindows[winType.FullName] = win;
            }

            if (isDialog)
                win.ShowDialog();
            else
                win.Show();
        }

        public void CreateEntityWindow(Type winType, Entity entity = null, bool isDialog = true)
        {
            Window win;  

            if (_entityWindows.ContainsKey(winType.FullName))
            {
                win = _entityWindows[winType.FullName];
            }
            else
            {
                win = (Window)Activator.CreateInstance(winType);

                MethodInfo setViewModel = winType.GetMethod("SetViewModel");

                if (entity == null)
                {
                    Type viewModelType = (Type)winType
                           .GetProperty("ViewModelType").GetValue(win);

                    setViewModel.Invoke(win,
                        new object[] {
                    Activator.CreateInstance(viewModelType)});
                }
                else
                {
                    Type viewModelType = (Type)winType
                         .GetProperty("ViewModelType").GetValue(win);

                    setViewModel.Invoke(win,
                        new object[] {
                    Activator.CreateInstance(viewModelType, entity)});
                }

                _entityWindows[winType.FullName] = win;
            }

            try
            {
                if (isDialog)
                    win.ShowDialog();
                else
                    win.Show();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowWindow<TWindow>()
        {
            _entityWindows[typeof(TWindow).FullName].Show();
        }

        public void ShowDialogWindow<TWindow>()
        {
            _entityWindows[typeof(TWindow).FullName].ShowDialog();
        }

        public void HideWindow<TWindow>()
        {
            _entityWindows[typeof(TWindow).FullName].Hide();
        }

        public void CloseWindow<TWindow>()
        {
            _entityWindows[typeof(TWindow).FullName].Close();
            _entityWindows.Remove(typeof(TWindow).FullName);
        }

        public void CloseWindow(Type windowType)
        {
            _entityWindows[windowType.FullName].Close();
            _entityWindows.Remove(windowType.FullName);
        }
    }
}
