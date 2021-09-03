using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbProject
{
    public class UserRepository : IUtenteRepository
    {

        public bool ControlloUsername(Utente utente)
        {
            List<Utente> utenti = TrovaUser();

            bool isAlreadyInUse = false;
            foreach (Utente utenteDB in utenti)
                if (utenteDB.Username == utente.Username)
                    isAlreadyInUse = true;

            return isAlreadyInUse;
        }

        public Utente Autenticazione(Utente utente)
        {
            List<Utente> utenti = TrovaUser();

            foreach (Utente utenteDB in utenti)
                if (utenteDB.Username == utente.Username && utenteDB.Password == utente.Password)
                {
                    utente = utenteDB;
                    utente.IsAuthenticated = true;
                }

            return utente;
        }

        public int RecuperaIdUtente(string user)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT Id FROM Utente WHERE @Username=Username";
                    command.Parameters.AddWithValue("@Username", user);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    conn.Close();
            }
        }

        public Utente NuovoUtente(Utente utente)
        {

            if (!ControlloUsername(utente))
            {
                using (SqlConnection conn = ConnectedMode.Connessione())
                {

                    string inserisci = @"INSERT INTO Utente(username, password, IsAdmin) VALUES " +
                                           $"('{utente.Username}','{utente.Password}',0); SELECT SCOPE_IDENTITY()";

                    SqlCommand command = new SqlCommand(inserisci, conn);
                    decimal riga = (decimal)command.ExecuteScalar();
                    utente.Id = (int)riga;
                    conn.Close();
                }
                utente.IsAuthenticated = true;
            }
            else
            {
                Console.WriteLine("Nome gia in uso.");
            }

            return utente;
        }

        public List<Utente> TrovaUser()
        {
            List<Utente> utenti = new List<Utente>();

            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand leggi = new("SELECT * FROM Utente", conn);

                SqlDataReader reader = leggi.ExecuteReader();

                while (reader.Read())
                {
                    string username = (string)reader[1];
                    string password = (string)reader[2];
                    bool isAdmin = (bool)reader[3];
                    int id = (int)reader[0];

                    Utente utente = new Utente(username, password, isAdmin, id);
                    utenti.Add(utente);

                }
                conn.Close();
            }
            return utenti;

        }

        public void UpdateUtente(Utente utente, int idUtente)
        {
            using (SqlConnection connection = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE Utente SET IsAdmin=@IsAdmin WHERE Id=@Id";
                    command.Parameters.AddWithValue("@IsAdmin", utente.IsAdmin);
                    command.Parameters.AddWithValue("@Id", idUtente);

                    SqlDataReader reader = command.ExecuteReader();

                    connection.Close();

            }
        }


    }
}
