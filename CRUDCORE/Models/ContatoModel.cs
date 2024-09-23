namespace CRUDCORE.Models
{
    /// <summary>
    /// Classe para CRUD no banco de dados - CREATE/UPDATE/DELETE
    /// SEMPRE QUE CHAMAR ESTA CLASSE IREI CRIAR UM OBJ CONTENDO OS DADOS QUE SERÃO SOLICITADOS
    /// </summary>
    public class ContatoModel
    {
        public int IdContato { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}
