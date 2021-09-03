using BusinessLayer;
using BusinessLayer.Modelli;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EroeServices
    {
        static EroeRepository er = new EroeRepository();

        //TROVA EROI
        public static List<Eroe> GetEroi(Utente utente, int idUtente)
        {
            return er.TrovaEroi(utente, idUtente);
        }

        //CONTROLLA CHE NON CI SIANO DOPPIONI
        public static bool VerificaNome(string nome)
        {
            return er.VerificaNome(nome);
        }

        //NUOVO EROE
        public static Eroe GetNuovoEroe(string nome, string categoria, int livello, string nomeArma, int puntiDanno)
        {
            return new Eroe(nome, categoria, 1, new Arma(nomeArma, puntiDanno), 20, 0);
        }

        //AGGIUNTA NUOVO EROE
        public static void AddEroe(Utente utente, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello)
        {

            er.AddEroi(utente, idUtente, e, idCategoria, idArma, idLivello);

        }

        //EROE PER ID
        public static int RecuperaIdEroe(Eroe e, Utente u, int idUtente)
        {
            return er.RecuperaIdEroe(u, e, idUtente);
        }

        //ELIMINA EROE
        public static void CancellaEroe(Utente utente, Eroe e, int idEroe)
        {
            er.CancellaEroe(e, utente, idEroe);
        }

        //AGGIORNA PUNTI
        public static void UpdatePunteggio(Eroe e, int idEroe, int idLivello)
        {
            er.UpdatePunteggio(e, idEroe, idLivello);
        }

        //RECUPERA CLASSIFICA
        public static Dictionary<Eroe, string> RecuperaClassifica()
        {
            return er.ClassificaGlobale();
        }





        public static List<Eroe> GetEroiPromozione(Utente utente, int idUtente, int idLivelloEroe)
        {
            return er.TrovaEroiPromozione(utente, idUtente, idLivelloEroe);
        }
    }
}

