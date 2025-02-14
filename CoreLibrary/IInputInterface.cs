using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public interface IInputInterface
    {
        Task<int> InputAttempt();//uso un metodo asincrono perchè con UI event driven (come WPF) devo attendere l'input dell'utente senza bloccare tutto!
    }
}
