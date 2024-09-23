using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    /// <summary>
    /// Classe para CRUD no banco de dados - CREATE/UPDATE/DELETE
    /// SEMPRE QUE CHAMAR ESTA CLASSE IREI CRIAR UM OBJ CONTENDO OS DADOS QUE SERÃO SOLICITADOS
    /// </summary>
    public class ContatoModel
    {
        public int IdContato { get; set; }
        [Required(ErrorMessage = "O campo 'Nome' é obrigatorio")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo 'Telefone' é obrigatorio")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "O campo 'Email' é obrigatorio")]
        public string? Email { get; set; }
    }
}
