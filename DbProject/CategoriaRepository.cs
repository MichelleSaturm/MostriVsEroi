using BusinessLayer.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //CATEGORIA EROI
        public List<string> TrovaCategorieEroi()
        {

            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT Nome FROM Categoria WHERE Tipo=@Tipo";
                    command.Parameters.AddWithValue("@Tipo", "Eroe");
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> categorie = new List<string>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];

                        categorie.Add(nome);

                    }
                    return categorie;
                    conn.Close();
            }

        }

        //CATEGORIA MOSTRI
        public List<string> TrovaCategorieMostri()
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT Nome FROM Categoria WHERE Tipo=@Tipo";
                    command.Parameters.AddWithValue("@Tipo", "Mostro");
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> categorie = new List<string>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];

                        categorie.Add(nome);

                    }
                    return categorie;
                    conn.Close();
            }
        }

        //CATEGORIA PER ID
        public int RecuperaIdCategoria(string categoria)
        {
            using (SqlConnection conn = ConnectedMode.Connessione())
            {
                
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT IdCategoria FROM Categoria WHERE @Nome=Nome";
                    command.Parameters.AddWithValue("@Nome", categoria);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    conn.Close();
            }
        }

    }
}
