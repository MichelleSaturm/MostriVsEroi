using BusinessLayer;
using BusinessLayer.Modelli;
using Services;
using System;
using System.Collections.Generic;

namespace Fantasia_Finale
{
    class GestioneMostri
    {
        //CREA NUOVO MOSTRO
        public static void CreaMostro(Utente utente, int idUtente)
        {
            Console.Clear();
            Console.WriteLine("==== CREA UN MOSTRO DA INSERIRE IN GIOCO ====");

            string nomeMostro;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Inserisci il nome del mostro:");
                nomeMostro = Console.ReadLine();
                if (MostroServices.VerificaNome(nomeMostro))
                {
                    Console.WriteLine("Mi dispiace è già stato inserito un mostro con questo nome.");
                }

            } while (MostroServices.VerificaNome(nomeMostro) || nomeMostro == null);

            Console.WriteLine();
            Console.WriteLine("Che tipo di mostro è?");
            string categoria = SceltaCategoria();
            if (categoria != null)
            {
                int idCategoria = CategoriaServices.RecuperaIdCategoria(categoria);
                Console.WriteLine();
                Console.WriteLine("Con quale arma il mostro seminerà distruzione?");
                Arma arma = SceltaArma(utente, categoria);
                if (arma != null)
                {
                    int idArma = ArmaServices.RecuperaIdArmi(arma);
                    Console.WriteLine();
                    Console.WriteLine($"Qual è il livello del mostro?");
                    int puntiVita = SceltaLivello();
                    int livello = LivelloVitaServices.RecuperaLivelloVita(puntiVita);
                    Mostro m = MostroServices.GetNuovoMostro(nomeMostro, categoria, livello, arma.NomeArma, arma.PuntiDanno, puntiVita);
                    int idLivello = LivelloVitaServices.RecuperaIdLivelloVita(m);
                    MostroServices.AddMostro(m, idCategoria, idArma, idLivello);
                    Console.WriteLine($"Il mostro {m.NomeMostro} è stato inserito con successo!");
                }
                else
                {
                    Console.WriteLine("Mi dispiace ma è necessario inserire un'arma.");
                }
            }
            else
            {
                Console.WriteLine("Mi dispiace ma è necessario inserire una classe per i mostri.");
            }
        }

        //SCEGLI CATEGORIA MOSTRO
        public static string SceltaCategoria()
        {
            List<string> categorie = CategoriaServices.GetCategoriaMostri();

            int scelta = 0;
            if (categorie.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var m in categorie)
                    {
                        Console.WriteLine($"[{count}] {m}");
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

        //SCEGLI ARMA MOSTRO
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
                Console.WriteLine("Non sono presenti armi");
                return null;
            }
        }

        //SCEGLI LIVELLO MOSTRO
        public static int SceltaLivello()
        {
            Dictionary<int, int> livelli = LivelloVitaServices.GetLivelli();

            int scelta = 0;
            if (livelli.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var l in livelli)
                    {
                        Console.WriteLine($"[{count++}] {l.Key} (Punti Vita: {l.Value})");

                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > livelli.Count);

                return livelli[scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti livelli.");
                return 0;
            }
        }


        //EXTRA

        //ELIMINA MOSTRO
        public static void EliminaMostro()
        {
            Console.Clear();
            Console.WriteLine("==== ELIMINA UN MOSTRO ====");
            Mostro m = ScegliMostroDaEliminare();
            int idMostro = MostroServices.RecuperaIdMostro(m);
            if (m != null)
            {

                MostroServices.CancellaMostro(m, idMostro);

                Console.WriteLine($"Il mostro {m.NomeMostro} è stato eliminato con successo!");
            }
        }

        //SCEGLI MOSTRO DA CANCELLARE
        public static Mostro ScegliMostroDaEliminare()
        {
            Console.WriteLine();
            Console.WriteLine("Quale di questi mostri desideri eliminare?");
            Console.WriteLine();
            List<Mostro> mostri = MostroServices.GetMostroLista();

            int scelta;
            if (mostri.Count > 0)
            {
                do
                {
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", "N°", "Nome Mostro", "Classe", "Liv", "HP", "Arma", "Danni");
                    Console.WriteLine(new String('-', 95));
                    int count = 1;
                    foreach (var m in mostri)
                    {
                        Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", count, m.NomeMostro, m.Categoria, m.Livello, m.PuntiVita, m.Arma.NomeArma, m.Arma.PuntiDanno);
                        count++;
                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > mostri.Count);

                return mostri[--scelta];
            }
            else
            {
                Console.WriteLine("Non ci sono mostri da eliminare!");
                return null;
            }

        }

        //LISTA MOSTRI
        public static void ListaMostri()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA MOSTRI PRESENTI IN GIOCO ===");
            Console.WriteLine();
            List<Mostro> mostri = MostroServices.GetMostroLista();

            if (mostri.Count > 0)
            {

                Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", "N°", "Nome Mostro", "Classe", "Liv", "HP", "Arma", "Danni");
                Console.WriteLine(new String('-', 95));
                int count = 1;
                foreach (var m in mostri)
                {
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", count, m.NomeMostro, m.Categoria, m.Livello, m.PuntiVita, m.Arma.NomeArma, m.Arma.PuntiDanno);
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Premi un tasto per tornare al menù");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Non ci sono mostri da visualizzare!");
                Console.WriteLine("Premi un tasto per tornare al menù");
                Console.ReadLine();
                return;
            }
        }
    }
}
