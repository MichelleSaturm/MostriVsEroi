using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfacce
{
    public interface ICategoriaRepository
    {
        public List<string> TrovaCategorieEroi();
        public List<string> TrovaCategorieMostri();
        public int RecuperaIdCategoria(string categoria);
    }
}
