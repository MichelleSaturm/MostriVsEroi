using BusinessLayer;
using BusinessLayer.Interfacce;
using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbProject
{
    public class EroeRepository : IEroeRepository
    {
        public List<Eroe> TrovaEroi(Utente utente, int idUtente)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "SELECT * FROM UtenteConEroi WHERE Id=@Id";
                    command.Parameters.AddWithValue("@Id", idUtente);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Eroe> eroi = new List<Eroe>();
                    while (reader.Read())
                    {
                        var nomeEroe = (string)reader["NomeEroe"];
                        var categoria = (string)reader["Categoria"];
                        var nomeArma = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];
                        var puntiAccumulati = (int)reader["PunteggioAccumulato"];

                        Eroe e = new Eroe(nomeEroe, categoria, livello, new Arma(nomeArma, puntiDanno), puntiVita, puntiAccumulati);

                        eroi.Add(e);
                    }
                    return eroi;
                    conn.Close();
            }
        }

        public bool VerificaNome(string nomeEroe)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe WHERE @NomeEroe=NomeEroe";
                command.Parameters.AddWithValue("@NomeEroe", nomeEroe);

                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
                conn.Close();
            }
        }

        public void AddEroi(Utente u, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "INSERT INTO Eroe VALUES (@NomeEroe,@IdCategoria,@IdArma,@IdLivelloVita,@PunteggioAccumulato,@IdUtente)";
                command.Parameters.AddWithValue("@NomeEroe", e.NomeEroe);
                command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                command.Parameters.AddWithValue("@IdArma", idArma);
                command.Parameters.AddWithValue("@IdLivelloVita", idLivello);
                command.Parameters.AddWithValue("@PunteggioAccumulato", 0);
                command.Parameters.AddWithValue("@IdUtente", idUtente);

                command.ExecuteNonQuery();

                conn.Close();

            }
        }

        public int RecuperaIdEroe(Utente u, Eroe e, int idUtente)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                if (e != null)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT IdEroe from Eroe WHERE NomeEroe=@NomeEroe AND IdUtente=@IdUtente";
                    command.Parameters.AddWithValue("@NomeEroe", e.NomeEroe);
                    command.Parameters.AddWithValue("@IdUtente", idUtente);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    conn.Close();
                }
                else
                    return 0;
            }
        }

        public void CancellaEroe(Eroe e, Utente u, int idEroe)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE Eroe WHERE IdEroe=@IdEroe";
                    command.Parameters.AddWithValue("@IdEroe", idEroe);
                    command.ExecuteNonQuery();
                    conn.Close();
             
            }
        }

        public void UpdatePunteggio(Eroe e, int idEroe, int idLivello)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE Eroe SET PunteggioAccumulato=@PunteggioAccumulato, IdLivelloVita=@IdLivelloVita WHERE IdEroe=@IdEroe";
                    command.Parameters.AddWithValue("@PunteggioAccumulato", e.PuntiAccumulati);
                    command.Parameters.AddWithValue("@IdLivelloVita", idLivello);
                    command.Parameters.AddWithValue("@IdEroe", idEroe);
                    SqlDataReader reader = command.ExecuteReader();

                    conn.Close();
                
            }
        }

        public Dictionary<Eroe, string> ClassificaGlobale()
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                Dictionary<Eroe, string> eroi = new Dictionary<Eroe, string>();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM ClassificaGlobale";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var user = (string)reader["Username"];
                        var nome = (string)reader["NomeEroe"];
                        var categoria = (string)reader["Categoria"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];
                        var puntiAccumulati = (int)reader["PunteggioAccumulato"];

                        Eroe e = new Eroe(nome, categoria, livello, puntiVita, puntiAccumulati);

                        eroi.Add(e, user);
                    }
                    return eroi;
                    conn.Close();
            }
        }




        public List<Eroe> TrovaEroiPromozione(Utente utente, int idUtente, int idLivelloEroe)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "SELECT * FROM UtenteConEroi WHERE Id=@Id AND Livello=@Livello";
                command.Parameters.AddWithValue("@Id", idUtente);
                command.Parameters.AddWithValue("@Livello", idLivelloEroe);
                SqlDataReader reader = command.ExecuteReader();
                List<Eroe> eroi = new List<Eroe>();
                while (reader.Read())
                {
                    var nomeEroe = (string)reader["NomeEroe"];
                    var categoria = (string)reader["Categoria"];
                    var nomeArma = (string)reader["NomeArma"];
                    var puntiDanno = (int)reader["PuntiDanno"];
                    var livello = (int)reader["Livello"];
                    var puntiVita = (int)reader["PuntiVita"];
                    var puntiAccumulati = (int)reader["PunteggioAccumulato"];

                    Eroe e = new Eroe(nomeEroe, categoria, livello, new Arma(nomeArma, puntiDanno), puntiVita, puntiAccumulati);

                    eroi.Add(e);
                }
                return eroi;
                conn.Close();
            }
        }
    }
}
