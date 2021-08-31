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
    public class RichiestaDati
    {
        //LOG-IN
        public static Utente InserisciUsernamePassword()
        {
            Console.Clear();
            Console.WriteLine("==== LOG-IN ====");

            string username;
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                if (username == null || username == " " || username == "")
                {
                    Console.WriteLine("Username non valido!!");
                }
            } while (username == null || username == " " || username == "");

            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (password == null || password == " " || password == "")
                {
                    Console.WriteLine("Password non valida");
                }
            } while (password == null || password == " " || password == "");

            return UtenteServices.GetUtente(username, password);
        }

        //REGISTRAZIONE NUOVO UTENTE
        public static Utente NuovoUsernamePassword()
        {
            Console.Clear();
            Console.WriteLine("==== REGISTRAZIONE ====");

            string username;
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                if (username == null || username == " " || username == "")
                {
                    Console.WriteLine("Username non valido!!");
                }
            } while (username == null || username == " " || username == "");

            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (password == null || password == " " || password == "")
                {
                    Console.WriteLine("Password non valida");
                }
            } while (password == null || password == " " || password == "");

            return UtenteServices.GetUtente(username, password);
        }
    }
}
