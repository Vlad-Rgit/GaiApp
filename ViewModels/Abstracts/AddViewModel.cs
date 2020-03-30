using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;
using GaiApp.Commands;

namespace GaiApp.ViewModels.Abstracts
{
    public class AddViewModel<TEntity> : SingleViewModel<TEntity>
        where TEntity: Entity
    {
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand => _saveCommand ??
            (_saveCommand = new RelayCommand(Save));

        protected bool _isToUpdate;

        protected AddViewModel(Entity entity) : base(entity)
        {
            _isToUpdate = entity == null ? false : true;  
        }

        public virtual void Save()
        {
            if (_isToUpdate == true)
            {
                _repo.Update(Entity);
            }
            else
            {
                _repo.Add(Entity);
            }

            _repo.SaveChanges();
        }
    }
}
