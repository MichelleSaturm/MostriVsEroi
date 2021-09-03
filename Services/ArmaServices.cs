using BusinessLayer;
using BusinessLayer.Modelli;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ArmaServices
    {
        static ArmaRepository ar = new ArmaRepository();

        //TROVA LE ARMI
        public static List<Arma> GetArmi(Utente utente, string categoria)
        {
            return ar.TrovaArmi(categoria);
        }

        //ARMI PER ID
        public static int RecuperaIdArmi(Arma arma)
        {
            return ar.RecuperaIdArma(arma);
        }
    }
}
