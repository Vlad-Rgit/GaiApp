using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Models
{
    public partial class Policeman
    {
        public string FIO
        {
            get => $"{LastName} {FirstName} {Patronymic}";
        }
    }
}
