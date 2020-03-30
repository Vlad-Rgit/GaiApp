using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.ViewModels.Abstracts;


namespace GaiApp.ViewModels
{
    public class AutoDetailViewModel : AddViewModel<Auto>
    {       
        public IList<Make> Makes { get; set; }
        public IList<Model> Models { get; set; }
        public IList<Color> Colors { get; set; }

        public AutoDetailViewModel(Entity entity) : base(entity)
        {
            Makes = _repo.GetAllOfType<Make>();
            Models = _repo.GetAllOfType<Model>();
            Colors = _repo.GetAllOfType<Color>();
        }
    }
}
