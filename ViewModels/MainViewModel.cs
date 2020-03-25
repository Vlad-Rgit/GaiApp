using GaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.ViewModels
{
    public class MainViewModel : EntityViewModel
    {
        public Policeman Policeman { get; set; }

        public MainViewModel(Entity entity)
        {
            Policeman = entity as Policeman;
        }
    }
}
