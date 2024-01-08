using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do Contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o E-mail do Contato")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Informe o telefone celular do Contato")]
        [Phone(ErrorMessage = "Informe um celular válido")]
        public string? Celular { get; set; }
    }
}
