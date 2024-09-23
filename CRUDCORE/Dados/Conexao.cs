using System.Data.SqlClient;

namespace CRUDCORE.Dados
{
    public class Conexao
    {
        private string ConnectionSQL = string.Empty;

        public Conexao()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            ConnectionSQL = builder.GetSection("ConnectionStrings:ConnectionSQL").Value;
        }

        public string getConnectionSQL()
        {
            return ConnectionSQL;
        }
    }
}
