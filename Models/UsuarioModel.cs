using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Usuario_id { get; set; }
        public string Usuario_nome { get; set; }
        public string Usuario_email { get; set; }
        public string Usuario_senha { get; set; }
    }
}