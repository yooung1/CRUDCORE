using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CRUDCORE.Dados
{
    public class ContatoDados
    {
        public  List<ContatoModel> Listar()
        {
            var objLista = new List<ContatoModel>();
            var cn = new Conexao();

            using (var connection = new SqlConnection(cn.getConnectionSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new ContatoModel()
                        {
                            IdContato =  Convert.ToInt32(dr["IdContato"]),
                            Nome = dr["Nome"].ToString(),
                            Telefone = dr["Telefone"].ToString(),
                            Email = dr["Email"].ToString(),
                        });
                    }
                }
            }
            return objLista;
        }

        public ContatoModel Obter(int IdContato)
        {
            var objContato = new ContatoModel();
            var cn = new Conexao();

            using (var connection = new SqlConnection(cn.getConnectionSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_Obter", connection);
                cmd.Parameters.AddWithValue("IdContato", IdContato);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objContato.IdContato = Convert.ToInt32(dr["IdContato"]);
                        objContato.Nome = dr["Nome"].ToString();
                        objContato.Telefone = dr["Telefone"].ToString();
                        objContato.Email = dr["Email"].ToString();
                    }
                }
            }
            return objContato;
        }

        public bool Guardar(ContatoModel objContato)
        {
            bool resposta;

            try
            {
                var cn = new Conexao();

                using (var connection = new SqlConnection(cn.getConnectionSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", connection);
                    cmd.Parameters.AddWithValue("Nome", objContato.Nome);
                    cmd.Parameters.AddWithValue("Telefone", objContato.Telefone);
                    cmd.Parameters.AddWithValue("Email", objContato.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resposta = false;
            }

            return resposta;
        }

        public bool Editar(ContatoModel objContato)
        {
            bool resposta;

            try
            {
                var cn = new Conexao();

                using (var connection = new SqlConnection(cn.getConnectionSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", connection);
                    cmd.Parameters.AddWithValue("IdContato", objContato.IdContato);
                    cmd.Parameters.AddWithValue("Nome", objContato.Nome);
                    cmd.Parameters.AddWithValue("Telefone", objContato.Telefone);
                    cmd.Parameters.AddWithValue("Email", objContato.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resposta = false;
            }

            return resposta;
        }

        public bool Eliminar(int IdContato)
        {
            bool resposta;

            try
            {
                var cn = new Conexao();

                using (var connection = new SqlConnection(cn.getConnectionSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", connection);
                    cmd.Parameters.AddWithValue("IdContato", IdContato);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resposta = false;
            }

            return resposta;
        }
    }
}
