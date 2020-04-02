using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.Commands;
using GaiApp.Services;

namespace GaiApp.ViewModels.Abstracts
{
    public class AddViewModel<TEntity> : SingleViewModel<TEntity>
        where TEntity: Entity, new()
    {
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand => _saveCommand ??
            (_saveCommand = new RelayCommand(Save));

        public bool IsToUpdate { get; private set; }

        protected AddViewModel(Entity entity) : base(entity)
        {
            IsToUpdate = entity == null ? false : true;  
        }

        public virtual void Save()
        {
            if (IsToUpdate == true)
            {
                _repo.Update(Entity);
            }
            else
            {
                _repo.Add(Entity);     
            }

            _repo.SaveChanges();

            WindowManager.Instance
                .CloseLastWindow();
        }
    }
}
