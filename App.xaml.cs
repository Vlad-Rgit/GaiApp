using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GaiApp.Windows;
using GaiApp.Services;

namespace GaiApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main()
        {
            App app = new App();
            app.InitializeComponent();

            LoginWindow win =
                WindowManager.Instance.CreateStartWindow();      

            app.Run(win);
        }

    }
}
