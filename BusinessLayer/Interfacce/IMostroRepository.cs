using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfacce
{
    public interface IMostroRepository
    {
        public List<Mostro> TrovaMostri();

        public void AddMostro(Mostro mostro, int idCategoria, int idArma, int idLivello);

        public bool VerificaNome(string nome);

        //EXTRA
        public List<Mostro> TrovaMostro();
        public int RecuperaIdMostro(Mostro m);
        public void CancellaMostro(Mostro m, int idMostro);
    }
}
