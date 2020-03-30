using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.EF.Repositories;
using GaiApp.Commands;
using System.Diagnostics;
using GaiApp.ViewModels.Abstracts;
using GaiApp.Services;
using GaiApp.Windows;
namespace GaiApp.ViewModels
{
    public class MainViewModel : SingleViewModel<Policeman>
    {
        private RelayCommand<News> _openBrowserLinkCommand;

        public RelayCommand<News> OpenBrowserLinkCommand =>
            _openBrowserLinkCommand ?? (_openBrowserLinkCommand = new RelayCommand<News>(OpenBrowser));

        public ObservableCollection<News> News { get; set; }

        public MainViewModel(Entity entity) : base(entity)
        {
            News = new ObservableCollection<News>(_repo.GetAllOfType<News>());
        }

        public void OpenBrowser(News news)
        {
            Process.Start(news.BrowserLink);
        }
    }
}
