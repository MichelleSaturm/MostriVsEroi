using BusinessLayer;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasia_Finale
{

    //DA CONTROLLARE UN LOOP DI MENU CAUSATO DALLA PROMOZIONE DA NON-ADMIN AD ADMIN
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
        public static void MenuAdmin(Utente utente, int idUtente)
        {

            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"==== BENTORNATO {utente.Username.ToUpper()} ====");
                Console.WriteLine();
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine("[4] Lista Eroi");
                Console.WriteLine();
                Console.WriteLine("== FUNZIONI ADMIN ==");
                Console.WriteLine("[5] Crea Nuovo Mostro");
                Console.WriteLine("[6] Elimina Mostro");
                Console.WriteLine("[7] Lista Mostri");
                Console.WriteLine("[8] Mostra Classifica Globale");
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
                        StartGame.Play(utente, idUtente);
                        Console.Clear();
                        break;
                    case 2:
                        GestioneEroi.Creazione(utente, idUtente);
                        Console.Clear();
                        break;
                    case 3:
                        GestioneEroi.EliminaEroe(utente, idUtente);
                        Console.Clear();
                        break;
                    case 4:
                        GestioneEroi.ListaEroi(utente, idUtente);
                        Console.Clear();
                        break;
                    case 5:
                        GestioneMostri.CreaMostro(utente, idUtente);
                        Console.Clear();
                        break;
                    case 6:
                        GestioneMostri.EliminaMostro();
                        Console.Clear();
                        break;
                    case 7:
                        GestioneMostri.ListaMostri();
                        Console.Clear();
                        break;
                    case 8:
                        GestioneClassifica.ClassificaGlobale();
                        Console.Clear();
                        break;
                    case 0:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
        }

        //MENU PER GLI UTENTI 
        public static void MenuNonAdmin(Utente utente, int idUtente)
        {

            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"==== BENTORNATO {utente.Username.ToUpper()} ====");
                Console.WriteLine();
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine("[4] Lista Eroi");
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
                        StartGame.Play(utente, idUtente);
                        Console.Clear();
                        break;
                    case 2:
                        GestioneEroi.Creazione(utente, idUtente);
                        Console.Clear();
                        break;
                    case 3:
                        GestioneEroi.EliminaEroe(utente,idUtente);
                        Console.Clear();
                        break;
                    case 4:
                        GestioneEroi.ListaEroi(utente, idUtente);
                        Console.Clear();
                        break;
                    case 0:
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
