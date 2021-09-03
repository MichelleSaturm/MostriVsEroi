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
    public class MostroServices
    {
        static MostroRepository mr = new MostroRepository();

        //TROVA MOSTRI
        public static List<Mostro> GetMostri(Utente utente)
        {
            return mr.TrovaMostri();
        }

        //CONTROLLO DOPPIONI
        public static bool VerificaNome(string nome)
        {
            return mr.VerificaNome(nome);
        }

        //CREAZIONE NUOVO MOSTRO
        public static Mostro GetNuovoMostro(string nome, string categoria, int livello, string nomeArma, int puntiDanno, int puntiVita)
        {
            return new Mostro(nome, categoria, new Arma(nomeArma, puntiDanno), livello, puntiVita);
        }
        
        //AGGIUNTA NUOVO MOSTRO
        public static void AddMostro(Mostro m, int idCategoria, int idArma, int idLivello)
        {
            mr.AddMostro(m, idCategoria, idArma, idLivello);
        }



        //EXTRA

        //LISTA MOSTRI
        public static List<Mostro> GetMostroLista()
        {
            return mr.TrovaMostro();
        }

        //RECUPERA ID MOSTRO
        public static int RecuperaIdMostro(Mostro m)
        {
            return mr.RecuperaIdMostro(m);
        }

        //ELIMINAZIONE MOSTRO
        public static void CancellaMostro(Mostro m, int idMostro)
        {
            mr.CancellaMostro(m, idMostro);
        }
    }
}
