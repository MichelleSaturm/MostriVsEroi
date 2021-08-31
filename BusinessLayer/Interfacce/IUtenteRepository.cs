using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUtenteRepository
    {
        public bool ControlloUsername(Utente utente);
        public Utente Autenticazione(Utente utente);
        public List<Utente> TrovaUser();
        public Utente NuovoUtente(Utente utente);
    }
}
