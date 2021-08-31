using BusinessLayer;
using DbProject;
using System;

namespace Services
{
    public class UtenteServices
    {
        public static Utente GetUtente(string username, string password)
        {
            return new Utente(username, password);
        }


        static UserRepository ur = new UserRepository();
        public static Utente Verifica(Utente utente)
        {
            return ur.Autenticazione(utente);
        }

        public static Utente Registrazione(Utente utente)
        {
            return ur.NuovoUtente(utente);
        }
    }
}
