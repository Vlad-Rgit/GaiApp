using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GaiApp.Models;
using GaiApp.Windows;

namespace GaiApp.Services
{
    public static class WindowManager
    {
        private static Dictionary<string,Window> _windows;

        public static void OpenMainMenu(Policeman policeman)
        {
            if (_windows.ContainsKey("MainWindow"))
            {
                (_windows["MainWindow"] as Window).ShowDialog();
            }
            else
            {
                MainWindow win = new MainWindow();
                win.ShowDialog();
            }
        } 
    }
}
