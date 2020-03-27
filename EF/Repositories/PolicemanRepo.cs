using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Models;

namespace GaiApp.EF.Repositories
{
    public class PolicemanRepo : Repository<Policeman>
    {
        public Policeman GetPoliceman(string policemanNumber, string password)
            => _set.FirstOrDefault(p => p.PolicemanNumber == policemanNumber &&
                                          p.Password == password);
        
    }
}
