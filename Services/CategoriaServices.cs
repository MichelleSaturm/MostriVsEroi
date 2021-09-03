using BusinessLayer;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriaServices
    {

        //CATEGORIA EROI
        static CategoriaRepository cr = new CategoriaRepository();
        public static List<string> GetCategoriaEroi(Utente utente)
        {
            return cr.TrovaCategorieEroi();
        }

        //CATEGORIA MOSTRI
        public static List<string> GetCategoriaMostri()
        {
            return cr.TrovaCategorieMostri();
        }

        //CATEGORIA PER ID
        public static int RecuperaIdCategoria(string categoria)
        {
            return cr.RecuperaIdCategoria(categoria);
        }

    }
}
