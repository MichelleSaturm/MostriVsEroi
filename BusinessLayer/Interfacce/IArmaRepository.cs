using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfacce
{
    public interface IArmaRepository
    {
        public List<Arma> TrovaArmi(string categoria);
        public int RecuperaIdArma(Arma arma);
    }
}
