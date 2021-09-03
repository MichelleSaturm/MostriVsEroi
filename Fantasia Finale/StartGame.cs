using BusinessLayer;
using BusinessLayer.Modelli;
using Services;
using System;
using System.Collections.Generic;

namespace Fantasia_Finale
{
    public class StartGame
    {
        //INIZIO GIOCO
        public static void Play(Utente utente, int idUtente)
        {
            Console.Clear();
            Console.WriteLine("==== F A N T A S I A    F I N A L E ====");
            Console.WriteLine("==== S T A R T ====");
            Console.WriteLine();
            Console.WriteLine("Scegli un tuo eroe per iniziare la tua avventura!");
            Eroe e = SceltaEroe(utente, idUtente);
            if (e != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Hai scelto {e.NomeEroe}!");
                Console.WriteLine();
                Console.WriteLine("ATTENZIONE!!\n" +
                    "E' APPENA APPARSO UN MOSTRO!\n" +
                    $"Premi un tasto per attivare l'abilità 'Scan' e scoprire contro chi deve scontrarsi {e.NomeEroe}!!");
                Console.ReadLine();
                int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);
                Console.WriteLine();
                Mostro m = SceltaMostro(utente, e);
                Console.WriteLine($"SCANSIONE MOSTRO ATTIVATA CON SUCCESSO!\n\n" +
                    $"Nome Mostro: {m.NomeMostro}\n" +
                    $"Categoria { m.Categoria}\n" +
                    $"Livello: {m.Livello}\n" +
                    $"HP: {m.PuntiVita}" +
                    $"\nArma: {m.Arma.NomeArma} [{m.Arma.PuntiDanno}]");
                int puntiVitaMostro = m.PuntiVita;
                int puntiVitaEroe = e.PuntiVita;
                Console.WriteLine();
                Partita(utente, e, m, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);

                //TERMINE PARTITA
                Console.WriteLine(new String('-', 80));
                string scelta;
                Console.WriteLine("Desideri fare un'altra parita a Fantasia Finale?\n" +
                    "Digita 'Y' se vuoi continuare a giocare, altrimenti premo un tasto qualsiasi.");
                scelta = Console.ReadLine();

                if (scelta == "y" || scelta == "Y")
                {
                    Play(utente, idUtente);
                }
                else
                {
                    utente = ControlloUtenteAdmin(utente, idUtente);
                    if (!utente.IsAdmin)
                    {
                        Menu.MenuNonAdmin(utente, idUtente);
                    }
                    else
                    {
                        Menu.MenuAdmin(utente, idUtente);
                    }
                }
            }
            else
            {
                Console.WriteLine("Oh! Qualcosa è andato storto!");
                Console.WriteLine();
                Console.WriteLine("Prima di giocare è necessario creare un Eroe!");
                Console.WriteLine("Premi un tasto per tornare al menù e procedere alla creazione!");
                Console.ReadLine();
            }
        }

        //SELEZIONE EROE
        public static Eroe SceltaEroe(Utente utente, int idUtente)
        {
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
                        Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}{4,-5}{5,-30}{6,-5}", count, e.NomeEroe, e.Categoria, e.Livello, e.PuntiVita, e.Arma.NomeArma, e.Arma.PuntiDanno);
                        count++;
                    }
                    Console.WriteLine();
                    Console.Write(">>> ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > eroi.Count);

                return eroi[--scelta];
            }
            else
            {
                return null;
            }

        }

        //GENERATORE CASUALE MOSTRI
        private static Mostro SceltaMostro(Utente utente, Eroe eroe)
        {
            List<Mostro> mostri = MostroServices.GetMostri(utente);
            Random r = new Random();
            int scelta = r.Next(0, mostri.Count);

            if (mostri[scelta].Livello <= eroe.Livello)
            {
                return mostri[scelta];
            }
            else
            {
                return SceltaMostro(utente, eroe);
            }
        }

        //INIZIO PARTITA
        public static void Partita(Utente utente, Eroe eroe, Mostro mostro, int hpMostro, int hpEroe, int idUtente, int idEroe)
        {
            Console.WriteLine();
            Console.WriteLine("Cosa vuoi fare?");
            int scelta;

            Console.WriteLine($"[1] {eroe.NomeEroe} attacca {mostro.NomeMostro}");
            Console.WriteLine($"[0] {eroe.NomeEroe} usa Fumogeno per tentare la fuga");

            do
            {
                Console.Write(">>> ");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta > 1 || scelta < 0);

            switch (scelta)
            {
                case 1:
                    Attacco(utente, eroe, mostro, hpMostro, hpEroe, idUtente, idEroe);
                    break;
                case 0:
                    Fuga(utente, eroe, mostro, hpMostro, hpEroe, idUtente, idEroe);
                    break;
                default:
                    Console.WriteLine("La scelta non è corretta! Riprova!");
                    break;
            }

        }

        //SCELTA: FUGA
        private static void Fuga(Utente utente, Eroe eroe, Mostro mostro, int hpMostro, int hpEroe, int idUtente, int idEroe)
        {
            bool[] verificaFuga = { true, false };
            Random r = new Random();
            int s = r.Next(0, verificaFuga.Length);

            Console.WriteLine();
            Console.WriteLine($"{eroe.NomeEroe} ha lanciato un Fumogeno!");

            if (verificaFuga[s])
            {
                Console.WriteLine($"SI! {eroe.NomeEroe} è riuscito a fuggire!!");
                eroe = CalcoloPunteggioFuga(mostro, eroe);
                Console.WriteLine();
                Console.WriteLine($"Calcolo Punti Esperienza per {eroe.NomeEroe}!\n" +
                    $"Punti guadagnati: {eroe.PuntiAccumulati}");
                Console.WriteLine();
                int idLivelloEroe = LivelloVitaServices.RecuperaIdLivelloVita(eroe);
                EroeServices.UpdatePunteggio(eroe, idEroe, idLivelloEroe);
            }
            else
            {
                Console.WriteLine($"OH NO! Il mostro non è cascato nella trappola di {eroe.NomeEroe}!");
                Console.WriteLine();
                Console.WriteLine($"{mostro.NomeMostro} si prepara all'attacco!");
                int nuovHPEroe = hpEroe - mostro.Arma.PuntiDanno;
                Console.WriteLine();
                Console.WriteLine($"{eroe.NomeEroe} dopo l'attacco di {mostro.NomeMostro} ha ancora {nuovHPEroe} HP");

                if (nuovHPEroe <= 0)
                {

                    Console.WriteLine($"L'ultimo attacco di {mostro.NomeMostro} è stato terribile... e {eroe.NomeEroe} non ha più energie per continuare a combattere.");
                    Console.WriteLine();
                    Console.WriteLine("==== HAI PERSO ====");
                }
                else
                {
                    hpEroe = nuovHPEroe;
                    Partita(utente, eroe, mostro, hpMostro, hpEroe, idUtente, idEroe);
                }
            }
        }

        //SCELTA: ATTACCO
        private static void Attacco(Utente utente, Eroe eroe, Mostro mostro, int hpMostro, int hpEroe, int idUtente, int idEroe)
        {
            Console.WriteLine($"\n{eroe.NomeEroe} si prepara ha colpire {mostro.NomeMostro}");

            int nuoviHPMostro = hpMostro - eroe.Arma.PuntiDanno;
            if (nuoviHPMostro <= 0)
            {
                Console.WriteLine($"Con quest'attacco {eroe.NomeEroe} ha sconfitto {mostro.NomeMostro}!!");
                Console.WriteLine();
                Console.WriteLine("==== HAI VINTO ====");
                ControlliPartita(eroe, mostro, utente, idUtente, idEroe);

            }
            else
            {
                Console.WriteLine();;
                Console.WriteLine($"E' stato un duro colpo! Ma {mostro.NomeMostro} è ancora vivo!\n" +
                    $"Dopo l'attacco di {eroe.NomeEroe} ha ancora {nuoviHPMostro} HP e si sta preparando per attaccare!");
                Console.WriteLine();
                int nuoviHPEroe = hpEroe - mostro.Arma.PuntiDanno;
                Console.WriteLine($"{eroe.NomeEroe} è riuscito a resistere all'attacco di {mostro.NomeMostro} con ancora {nuoviHPEroe} HP!");

                if (nuoviHPEroe <= 0)
                {
                    Console.WriteLine($"L'ultimo attacco di {mostro.NomeMostro} è stato terribile... e {eroe.NomeEroe} non ha più energie per continuare a combattere.");
                    Console.WriteLine();
                    Console.WriteLine("==== HAI PERSO ====");
                }
                else
                {
                    hpMostro = nuoviHPMostro;
                    hpEroe = nuoviHPEroe;
                    Partita(utente, eroe, mostro, hpMostro, hpEroe, idUtente, idEroe);

                }

            }
        }

        //CONTROLLI PER PUNTEGGIO PARTITA
        private static void ControlliPartita(Eroe e, Mostro m, Utente utente, int idUtente, int idEroe)
        {
            e = CalcoloPunteggio(m.Livello, e);
            Console.WriteLine($"Calcolo Punti Esperienza per {e.NomeEroe}\n" +
                   $"Punti guadagnati: {e.PuntiAccumulati}");
            Console.WriteLine();
            int idLivelloEroe = LivelloVitaServices.RecuperaIdLivelloVita(e);
            EroeServices.UpdatePunteggio(e, idEroe, idLivelloEroe);
            //ControlloPunteggio(utente, idUtente);
            ControlloPunteggio(utente, idUtente, idLivelloEroe);

            //utente = ControlloUtenteAdmin(utente, idUtente);

            utente = Promozione(utente, idUtente,idLivelloEroe);
            UtenteServices.UpdateUtente(utente, idUtente);
        }

        //PUNTEGGI
        private static Eroe CalcoloPunteggio(int livelloMostro, Eroe e)
        {
            e.PuntiAccumulati += livelloMostro * 10;

            return e;
        }

        //PUNTEGGI IN CASO DI FUGA
        private static Eroe CalcoloPunteggioFuga(Mostro m, Eroe e)
        {
            //SE FUGGE E I PUNTI ACCUMULATI SONO 0 RIMANE COSI'
            if (e.PuntiAccumulati == 0)
            {
                return e;
            }
            //SE FUGGE E I PUNTI ACCUMULATI SONO SUPERIORI A 0 FA LA SOTTRAZIONE
            else
            {
                e.PuntiAccumulati -= m.Livello * 5;
                return e;
            }
        }

        //CONTROLLO PER LEVEL UP #2
        private static void ControlloPunteggio(Utente utente, int idUtente, int idLivelloEroe)
        {
            List<Eroe> eroi = EroeServices.GetEroiPromozione(utente, idUtente, idLivelloEroe);

            foreach (var eroe in eroi)
            {
                if (eroe.PuntiAccumulati > 29 && eroe.Livello == 1)
                {
                    //EROE LIVELLO 2
                    LevelUp(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 59 && eroe.Livello == 2)
                {
                    //EROE LIVELLO 3
                    LevelUp(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 89 && eroe.Livello == 3)
                {
                    //EROE LIVELLO 4
                    LevelUp(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 119 & eroe.Livello == 4)
                {
                    //EROE LIVELLO 5
                    LevelUp(eroe, utente, idUtente);
                }
                //if (eroe.Livello == 5)
                //{
                //    Console.WriteLine("!! Livello massimo raggiunto");
                //}

            }
        }

        ////CONTROLLO PER LEVEL UP #1
        //private static void ControlloPunteggio(Utente utente, int idUtente)
        //{
        //    List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

        //    foreach (var eroe in eroi)
        //    {
        //        if (eroe.PuntiAccumulati > 29 && eroe.Livello == 1)
        //        {
        //            LevelUp(eroe, utente, idUtente);
        //        }
        //        if (eroe.PuntiAccumulati > 59 && eroe.Livello == 2)
        //        {
        //            LevelUp(eroe, utente, idUtente);
        //        }
        //        if (eroe.PuntiAccumulati > 89 && eroe.Livello == 3)
        //        {
        //            LevelUp(eroe, utente, idUtente);
        //        }
        //        if (eroe.PuntiAccumulati > 119 & eroe.Livello == 4)
        //        {
        //            LevelUp(eroe, utente, idUtente);
        //        }

        //    }
        //}

        /*LEVEL UP CON AGGIORNAMENTO DEL DB*/       
        private static void LevelUp(Eroe e, Utente utente, int idUtente)
        {
            e.Livello += 1;
            int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);
            int idLivello = LivelloVitaServices.RecuperaIdLivelloVita(e);
            e.PuntiAccumulati = 0;
            EroeServices.UpdatePunteggio(e, idEroe, idLivello);
            Console.WriteLine($"{e.NomeEroe} è salito a livello {e.Livello}!\n\n" +
                $"NB: Se il tuo eroe ha raggiunto il livello 3 avrai accesso ai privilegi di admin!");
        }

        //CONTROLLO PER UTENTE ADMIN
        private static Utente Promozione(Utente utente, int idUtente, int idLivelloEroe)
        {
            if (utente.IsAdmin)
            {
                return utente;
            }
            else
            {
                if (idLivelloEroe == 3)
                {
                    utente.IsAdmin = true;
                    Console.WriteLine(new String('-', 95));
                    Console.WriteLine($"Complimenti {utente.Username}!! Hai i privilegi di admin!");
                }
            }

            return utente;
        }

        //CONTROLLO PER UTENTE ADMIN
        private static Utente ControlloUtenteAdmin(Utente utente, int idUtente)
        {
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            foreach (var e in eroi)
            {
                if (e.Livello == 3)
                {
                    utente.IsAdmin = true;
                    //Console.WriteLine(new String('-', 95));
                    //Console.WriteLine($"Con questa battaglia {e.NomeEroe} è salito a livello 3!\n" +
                    //    "Hai ottenuto i privilegi di admin!\n" +
                    //    $"Complimenti {utente.Username}!!");
                    break;
                }
            }

            return utente;
        }
    }
}
