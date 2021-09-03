using BusinessLayer;
using System;
using System.Data.SqlClient;

namespace DbProject
{
    public static class ConnectedMode
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FantasiaFinale;Trusted_Connection=True;";
        public static SqlConnection Connessione()
        {
            try
            {
                SqlConnection connection;
                connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Eccezione: {ex.Message}");
                throw new Exception("ATTENZIONE! C'è stato un piccolo intoppo nella connessione al database", ex);
            }


        }


    }
}