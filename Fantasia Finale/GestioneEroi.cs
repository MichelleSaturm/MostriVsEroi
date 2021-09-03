using BusinessLayer;
using BusinessLayer.Modelli;
using Services;
using System;
using System.Collections.Generic;

namespace Fantasia_Finale
{
    class GestioneEroi
    {
        //CREA EROE
        public static void Creazione(Utente utente, int idUtente)
        {
            Console.Clear();
            Console.WriteLine("==== CREA IL TUO EROE ====");
            string nomeEroe;
            do
            {
                Console.WriteLine("Inserisci il nome dell'eroe:");
                nomeEroe = Console.ReadLine();
                if (EroeServices.VerificaNome(nomeEroe))
                {
                    Console.WriteLine("Mi dispiace. Ma hai già inserito questo Eroe!");
                    Console.WriteLine();
                }

            } while (EroeServices.VerificaNome(nomeEroe) || nomeEroe == null);

            Console.WriteLine();
            Console.WriteLine("Il tuo eroe è un fortissimo guerriero o un astuto mago?");
            string categoria = SceltaCategoria(utente);

            if (categoria != null)
            {
                int idCategoria = CategoriaServices.RecuperaIdCategoria(categoria);
                Console.WriteLine();
                Console.WriteLine("Qual è l'arma a disposizione del tuo eroe?");
                Arma arma = SceltaArma(utente, categoria);

                if (arma != null)
                {
                    int idArma = ArmaServices.RecuperaIdArmi(arma);
                    Eroe e = EroeServices.GetNuovoEroe(nomeEroe, categoria, 1, arma.NomeArma, arma.PuntiDanno);
                    int idLivello = LivelloVitaServices.RecuperaIdLivelloVita(e);
                    EroeServices.AddEroe(utente, idUtente, e, idCategoria, idArma, idLivello);
                    Console.WriteLine($"L'eroe {e.NomeEroe} è stato inserito con successo!");
                }
                else
                {
                    Console.WriteLine("Mi dispiace ma è necessario inserire un'arma.");
                }
            }
            else
            {
                Console.WriteLine("Mi dispiace ma è necessario inserire una classe per gli eroi.");
            }
        }

        //ELIMINA EROE
        public static void EliminaEroe(Utente utente, int idUtente)
        {
            Console.Clear();
            Console.WriteLine("==== ELIMINA UNO DEI TUOI EROI ====");
            Eroe e = ScegliEroeDaEliminare(utente, idUtente);
            int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);
            if (e != null)
            {
                EroeServices.CancellaEroe(utente, e, idEroe);
                Console.WriteLine($"L'Eroe {e.NomeEroe} è stato eliminato con successo!");
            }
        }

        //SCEGLI CATEGORIA EROI
        public static string SceltaCategoria(Utente utente)
        {
            List<string> categorie = CategoriaServices.GetCategoriaEroi(utente);

            int scelta = 0;
            if (categorie.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var c in categorie)
                    {
                        Console.WriteLine($"[{count}] {c}");
                        count++;
                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > categorie.Count);

                return categorie[--scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti categorie");
                return null;
            }
        }

        //SCEGLI ARMA EROI
        public static Arma SceltaArma(Utente utente, string categoria)
        {
            List<Arma> armi = ArmaServices.GetArmi(utente, categoria);

            int scelta = 0;
            if (armi.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var a in armi)
                    {
                        Console.WriteLine($"[{count++}] {a.NomeArma} (Punti Danno: {a.PuntiDanno})");
                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > armi.Count);

                return armi[--scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti armi!");
                return null;
            }
        }

        //SCEGLI EROE DA CANCELLARE
        public static Eroe ScegliEroeDaEliminare(Utente utente, int idUtente)
        {
            Console.WriteLine();
            Console.WriteLine("Quale di questi eroi desideri eliminare?");
            Console.WriteLine();
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            int scelta;
            if (eroi.Count > 0)
            {
                do
                {
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", "N°", "Nome Eroe", "Classe", "Liv", "HP", "Arma", "Danni");
                    Console.WriteLine(new String('-', 95));
                    int count = 1;
                    foreach (var e in eroi)
                    {
                        Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", count, e.NomeEroe.ToUpper(), e.Categoria, e.Livello, e.PuntiVita, e.Arma.NomeArma, e.Arma.PuntiDanno);
                        count++;
                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > eroi.Count);

                return eroi[--scelta];
            }
            else
            {
                Console.WriteLine("OH! C'è stato un piccolo imprevisto!");
                Console.WriteLine("Devi creare un eroe prima di poterlo eliminare!\n" +
                    "Premi un tasto per tornare al menù e creare un personaggio.");
                Console.ReadLine();
                return null;
            }

        }


        //EXTRA

        //LISTA EROI
        public static void ListaEroi(Utente utente, int idUtente)
        {
            Console.Clear();
            Console.WriteLine($"=== LISTA EROI DI {utente.Username.ToUpper()} ===");
            Console.WriteLine();
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            if (eroi.Count > 0)
            {
                Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", "N°", "Nome Eroe", "Classe", "Liv", "HP", "Arma", "Danni");
                Console.WriteLine(new String('-', 95));
                int count = 1;
                foreach (var e in eroi)
                {
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", count, e.NomeEroe.ToUpper(), e.Categoria, e.Livello, e.PuntiVita, e.Arma.NomeArma, e.Arma.PuntiDanno);
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Premi un tasto per tornare al menù");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("OH! C'è stato un piccolo imprevisto!");
                Console.WriteLine("Non hai ancora creato dei personaggi!!");
                Console.ReadLine();
                return;
            }
        }
    }
}

