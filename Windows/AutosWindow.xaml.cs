using GaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GaiApp.ViewModels;
using GaiApp.Windows.Abstracts;
using System.Windows.Media.Effects;

namespace GaiApp.Windows
{
    /// <summary>
    /// Interaction logic for AutosWindow.xaml
    /// </summary>
    public partial class AutosWindow : EntityWindow<AutosViewModel, Auto>
    {

        public AutosWindow()
        {
            InitializeComponent();
        
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
