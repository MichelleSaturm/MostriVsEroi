using BusinessLayer;
using DbProject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasia_Finale
{
    class Accedi
    {
        public static void Login()
        {
            Utente utente = RichiestaDati.InserisciUsernamePassword();
            utente = UtenteServices.Verifica(utente);
            if (utente.IsAuthenticated)
            {
                if (RuoloIsAdmin(utente))
                    //UTENTE E' UN ADMIN
                    Menu.MenuAdmin(utente);
                else
                    //UTENTE NON E' UN ADMIN
                    Menu.MenuNonAdmin(utente);
            }
            else
            {
                //UTENTE NON REGISTRATO
                Console.WriteLine("Mi dispiace, ma non sei ancora registrato su Fantasia Finale.\n" +
                    "Premi un tasto per tornare al menù principale ed eseguire la registrazione!");
                Console.ReadLine();
            }
        }


        public static bool RuoloIsAdmin(Utente utente)
        {
            if (utente.IsAdmin)
                return true;
            else
                return false;
        }

        public static void Registrati()
        {
            Utente utente = RichiestaDati.NuovoUsernamePassword();
            utente = UtenteServices.Registrazione(utente);

            if (utente.IsAuthenticated)
            {
                if (!RuoloIsAdmin(utente))
                {
                    Console.WriteLine("La registrazione è avvenuta con successo!\n" +
                        "Premi un tasto per fare il log-in con le tue credenziali!");
                    Console.ReadLine();
                    Login();
                }
            }
        }
    }
}
