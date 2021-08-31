using BusinessLayer;
using System;
using System.Data.SqlClient;

namespace DbProject
{
    public static class ConnectedMode
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MostriVsEroi;Trusted_Connection=True;";
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
                Console.WriteLine($"Exception: {ex.Message}");
                throw new Exception("C'è stato un problema con la connessione al database", ex);
            }


        }


    }
}