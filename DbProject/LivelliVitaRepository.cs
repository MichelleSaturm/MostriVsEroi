using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class LivelliVitaRepository
    {
        public int RecuperaIdLivelliVita(Eroe e)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT IdLivelloVita FROM LivelloVita WHERE @Livello=Livello";
                command.Parameters.AddWithValue("@Livello", e.Livello);
                int id = (int)command.ExecuteScalar();
                return id;
                conn.Close();
            }
        }

        public int RecuperaIdLivelliVita(Mostro m)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT IdLivelloVita FROM LivelloVita WHERE @Livello=Livello";
                command.Parameters.AddWithValue("@Livello", m.Livello);
                int id = (int)command.ExecuteScalar();
                return id;
                conn.Close();
            }
        }

        public int RecuperaLivelliVita(int puntiVita)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Livello FROM LivelloVita WHERE @PuntiVita=PuntiVita";
                command.Parameters.AddWithValue("@PuntiVita", puntiVita);
                int id = (int)command.ExecuteScalar();
                return id;
                conn.Close();
            }
        }

        public Dictionary<int, int> GetLivelli()
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM LivelloVita";
                    SqlDataReader reader = command.ExecuteReader();
                    Dictionary<int, int> livelli = new Dictionary<int, int>();
                    while (reader.Read())
                    {
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];

                        livelli.Add(livello, puntiVita);
                    }

                    return livelli;

                    conn.Close();
            }
        }
    }
}
