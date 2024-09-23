using System.Data.SqlClient;

namespace CRUDCORE.DataBase
{
    /// <summary>
    /// Esta Classe é responsavel por gerar a string de conexao ao banco de dados, os dados de acesso estão no 'appssettings.json'
    /// Sempre que esta classe for chamada, ira criar um objeto contendo a conexao do banco
    /// </summary>
    public class Conexao
    {
        private string ConnectionSQL;

        public Conexao()
        {
            // Aqui estou dizendo onde o programa pode encontrar os dados de conexao ao meu banco de dados local
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            // Aqui estou indicando em qual dos campos estao as minhas chaves
            ConnectionSQL = builder.GetSection("ConnectionStrings:ConnectionSQL").Value;
        }

        public string getConnectionSQL()
        {
            // Retornando string de conexao
            return ConnectionSQL;
        }
    }
}
