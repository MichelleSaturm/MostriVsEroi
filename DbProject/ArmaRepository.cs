using BusinessLayer.Modelli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class ArmaRepository
    {
        public List<Arma> TrovaArmi(string categoria)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT NomeArma, PuntiDanno FROM ArmiConCategorieEroiEMostri WHERE Categoria=@Categoria";
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Arma> armi = new List<Arma>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];


                        Arma a = new Arma(nome, puntiDanno);
                        armi.Add(a);

                    }
                    return armi;
                    conn.Close();
            }
        }

        public int RecuperaIdArma(Arma arma)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
               
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT IdArma FROM Arma WHERE @NomeArma=NomeArma";
                    command.Parameters.AddWithValue("@NomeArma", arma.NomeArma);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    conn.Close();
            }
        }
    }
}
