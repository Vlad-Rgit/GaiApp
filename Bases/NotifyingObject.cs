using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Bases
{
    public class NotifyingObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
