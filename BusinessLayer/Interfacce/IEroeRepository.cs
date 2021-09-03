using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfacce
{
    public interface IEroeRepository
    {
        public List<Eroe> TrovaEroi(Utente utente, int idUtente);
        public void AddEroi(Utente u, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello);
        public void CancellaEroe(Eroe e, Utente u, int idEroe);
        public void UpdatePunteggio(Eroe e, int idEroe, int idLivello);
        public bool VerificaNome(string nome);
        public int RecuperaIdEroe(Utente u, Eroe e, int idUtente);
        public Dictionary<Eroe, string> ClassificaGlobale();



        public List<Eroe> TrovaEroiPromozione(Utente utente, int idUtente, int idLivelloEroe);
    }
}
