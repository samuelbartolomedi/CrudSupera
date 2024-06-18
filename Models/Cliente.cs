using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudSupera.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(80, ErrorMessage = "O nome do clinte deve conter até 80 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome do clinte deve conter no mínimo 5 caracteres!")]
        [DisplayName("Nome completo:")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        [DisplayName("Email:")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF!")]
        [StringLength(11, ErrorMessage = "O CPF deve conter 11 caracteres!")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 caracteres!")]
        [DisplayName("CPF:")]
        public string Cpf { get; set; } = string.Empty;

        public List<Assinatura> Assinaturas { get; set; } = new();
    }
}
