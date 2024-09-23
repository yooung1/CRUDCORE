using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CRUDCORE.DataBase
{
    /// <summary>
    /// Esta classe sera responsavel por todos os metodos disponiveis no banco de dados (CRUD)
    /// </summary>
    public class ContatoDados
    {
        /// <summary>
        /// METODO LISTAR
        /// Funcionalidade: Serve para procurar todos os itens disponiveis no banco de dados
        /// Cria uma lista de objetos da clase 'ContatoModel' e retorna ela no 'objLista'
        /// select * from CONTATO where IdContato = @IdContato
        /// </summary>
        public List<ContatoModel> Listar()
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

        /// <summary>
        /// METODO OBTER
        /// Funcionalidade: Serve para procurar um item especifico no banco de dados
        /// Retorna o item especifico
        /// select * from CONTATO where IdContato = @IdContato
        /// </summary>
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

        /// <summary>
        /// METODO GUARDAR
        /// Funcionalidade: Serve para salvar os dados do objeto criado
        /// insert into CONTATO(Nome,Telefone,Email) values (@Nome,@Telefone,@Email)
        /// </summary>
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

        /// <summary>
        /// METODO EDITAR
        /// Funcionalidade: Serve para alterar os dados de um dado no banco de dados
        /// update CONTATO set Nome = @Nome, Telefone = @Telefone, Email = @Email where IdContato = @IdContato
        /// </summary>
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
