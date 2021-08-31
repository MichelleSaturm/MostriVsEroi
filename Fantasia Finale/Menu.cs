using BusinessLayer;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasia_Finale
{
    class Menu
    {
        //MENU LOG-IN/REGISTRAZIONE
        public static void MenuPrincipale()
        {

            bool continuare = true;
            do
            {
                Console.WriteLine("==== BENVENUTO/A SU FANTASIA FINALE ====");
                Console.WriteLine("[1] Accedi");
                Console.WriteLine("[2] Registrati");
                Console.WriteLine();
                Console.WriteLine("[0] Esci");
                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);


                switch (choice)
                {
                    case 1:
                        Accedi.Login();
                        Console.Clear();
                        break;
                    case 2:
                        Accedi.Registrati();
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Grazie per aver scelto di giocare con noi!\n" +
                            "Ti aspettiamo per altre fantastiche partite!\n" +
                            "See ya!!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
        }

        //MENU PER GLI UTENTI ADMIN
        public static void MenuAdmin(Utente utente)
        {

            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==== BENTORNATO ====");
                Console.WriteLine($"Utente: {utente.Username}");
                Console.WriteLine();
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine("[4] Crea Nuovo Mostro");
                Console.WriteLine("[5] Mostra Classifica Globale");
                Console.WriteLine();
                Console.WriteLine("[0] Log-out");
                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);


                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO GIOCARE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO DI CREARE UN NUOVO EROE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO DI ELIMINARE UN EROE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("HAI CREARE UN NUOVO MOSTRO");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO DI VISUALIZZARE LA CLASSIFICA GLOBALE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Hai effettuato il Log-out!\n" +
                            "Grazie per aver giocato con noi!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
        }

        //MENU PER GLI UTENTI 
        public static void MenuNonAdmin(Utente utente)
        {

            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==== BENTORNATO ====");
                Console.WriteLine($"Utente: {utente.Username}");
                Console.WriteLine();
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine();
                Console.WriteLine("[0] Log-out");
                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);


                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO GIOCARE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO DI CREARE UN NUOVO EROE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("HAI SCELTO DI ELIMINARE UN EROE");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Hai effettuato il log-out!\n" +
                            "Grazie per aver giocato con noi!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
        }
    }
}
