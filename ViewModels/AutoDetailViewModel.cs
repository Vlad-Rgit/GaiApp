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
    public sealed class AutoDetailViewModel : AddViewModel<Auto>
    {

        private Make _selectedMake;
        private Model _selectedModel;
        private IList<Model> _models;
        private string _driverLicense;

        public IList<Make> Makes { get; set; }
        public IList<Color> Colors { get; set; }
        public IList<Driver> Drivers { get; set; }

        public IList<Model> Models
        {
            get => _models;
            set
            {
                _models = value;
                OnPropertyChanged();
            }
        }

  

        public Make SelectedMake
        {
            get => _selectedMake;
            set
            {
                _selectedMake = value;
                Entity.AutoType.Make = _selectedMake;

                Models = _selectedMake.AutoTypes.
                    Select(a => a.Model).ToList();
            }
        }

        public Model SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;

                Entity.AutoType =
                    _repo.GetOfType<AutoType>(_selectedMake.MakeId, _selectedModel.ModelId);
            }
        }


        public string DriverLicense
        {
            get => _driverLicense;
            set
            {
                _driverLicense = value;
                Driver driver = _repo.GetOfType<Driver>(_driverLicense);

                if (driver == null)
                {
                    throw new ArgumentException("Такого водителя нет");
                }
                else
                {
                    Entity.Driver = driver;
                }
            }
        }


        public AutoDetailViewModel(Entity entity) : base(entity)
        {
            Makes = _repo.GetAllOfType<Make>();

            if (Entity.VIN == null)
                SelectedMake = Makes[0];
            else
            {
                SelectedMake = Entity.AutoType.Make;
                SelectedModel = Entity.AutoType.Model;
                DriverLicense = Entity.DriverLicense;
            }

            Models = SelectedMake.AutoTypes.
                 Select(a => a.Model).ToList();

            Colors = _repo.GetAllOfType<Color>();

            Drivers = _repo.GetAllOfType<Driver>();
        }

  
    }
}
