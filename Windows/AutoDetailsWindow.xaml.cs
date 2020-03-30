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
using GaiApp.Models;
using GaiApp.Windows.Abstracts;

namespace GaiApp.Windows
{
    /// <summary>
    /// Interaction logic for AutoDetailsWindow.xaml
    /// </summary>
    public partial class AutoDetailsWindow : EntityWindow<AutoDetailViewModel, Auto>
    {
        public AutoDetailsWindow()
        {
            InitializeComponent();
        }
    }
}
