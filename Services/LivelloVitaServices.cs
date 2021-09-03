using BusinessLayer.Modelli;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LivelloVitaServices
    {
        static LivelliVitaRepository lvr = new LivelliVitaRepository();

        //ID HP EROE
        public static int RecuperaIdLivelloVita(Eroe e)
        {
            return lvr.RecuperaIdLivelliVita(e);
        }

        //ID HP MOSTRO
        public static int RecuperaIdLivelloVita(Mostro m)
        {
            return lvr.RecuperaIdLivelliVita(m);
        }

        //RECUPERA LIVELLO HP
        public static int RecuperaLivelloVita(int puntiVita)
        {
            return lvr.RecuperaLivelliVita(puntiVita);
        }

        //RECUPERA TUTTI I LIVELLI
        public static Dictionary<int, int> GetLivelli()
        {
            return lvr.GetLivelli();
        }
    }
}
