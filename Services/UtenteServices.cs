using BusinessLayer;
using DbProject;
using System;

namespace Services
{
    public class UtenteServices
    {
        static UserRepository ur = new UserRepository();

        //LOG-IN
        public static Utente GetUtente(string username, string password)
        {
            return new Utente(username, password);
        }
        
        //AUTENTICAZIONE
        public static Utente Verifica(Utente utente)
        {
            return ur.Autenticazione(utente);
        }

        //SIGN-IN
        public static Utente Registrazione(Utente utente)
        {
            return ur.NuovoUtente(utente);
        }

        //ID UTENTE
        public static int RecuperaIdUtente(Utente utente)
        {
            return ur.RecuperaIdUtente(utente.Username);
        }

        //AGGIORNA UTENTE 
        public static void UpdateUtente(Utente utente, int idUtente)
        {
            ur.UpdateUtente(utente, idUtente);
        }
    }
}
