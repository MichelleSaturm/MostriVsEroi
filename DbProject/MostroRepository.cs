using BusinessLayer;
using BusinessLayer.Interfacce;
using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class MostroRepository : IMostroRepository
    {
        public bool VerificaNome(string nomeMostro)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM Mostro WHERE @NomeMostro=NomeMostro";
                    command.Parameters.AddWithValue("@NomeMostro", nomeMostro);

                    SqlDataReader reader = command.ExecuteReader();
                    return reader.HasRows;
                    conn.Close();
            }
        }

        public List<Mostro> TrovaMostri()
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "SELECT * FROM MostriConCaratteristiche";

                    SqlDataReader reader = command.ExecuteReader();
                    List<Mostro> mostri = new List<Mostro>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["NomeMostro"];
                        var categoria = (string)reader["Classe"];
                        var nomeArma = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];


                        Mostro m = new Mostro(nome, categoria, new Arma(nomeArma, puntiDanno), livello, puntiVita);

                        mostri.Add(m);
                    }
                    return mostri;
                    conn.Close();
            }
        }

        public void AddMostro(Mostro m, int idCategoria, int idArma, int idLivello)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "INSERT INTO Mostro VALUES (@NomeMostro,@IdArma,@IdCategoria,@IdLivelloVita)";
                    command.Parameters.AddWithValue("@NomeMostro", m.NomeMostro);
                    command.Parameters.AddWithValue("@IdArma", idArma);
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    command.Parameters.AddWithValue("@IdLivelloVita", idLivello);

                    command.ExecuteNonQuery();

                    conn.Close();
            }
        }

        //EXTRA
        public List<Mostro> TrovaMostro()
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "SELECT * FROM MostriConCaratteristiche";

                SqlDataReader reader = command.ExecuteReader();
                List<Mostro> mostri = new List<Mostro>();
                while (reader.Read())
                {
                    var nome = (string)reader["NomeMostro"];
                    var categoria = (string)reader["Classe"];
                    var nomeArma = (string)reader["NomeArma"];
                    var puntiDanno = (int)reader["PuntiDanno"];
                    var livello = (int)reader["Livello"];
                    var puntiVita = (int)reader["PuntiVita"];


                    Mostro m = new Mostro(nome, categoria, new Arma(nomeArma, puntiDanno), livello, puntiVita);

                    mostri.Add(m);
                }
                return mostri;
                conn.Close();
            }
        }

        public int RecuperaIdMostro(Mostro m)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT IdMostro from Mostro WHERE NomeMostro=@NomeMostro";
                command.Parameters.AddWithValue("@NomeMostro", m.NomeMostro);
                int id = (int)command.ExecuteScalar();
                return id;
                conn.Close();
            }
        }

        public void CancellaMostro(Mostro m, int idMostro)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE Mostro WHERE IdMostro=@IdMostro";
                command.Parameters.AddWithValue("@IdMostro", idMostro);
                command.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
