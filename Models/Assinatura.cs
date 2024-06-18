using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CrudSupera.Models
{
    public class Assinatura
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Assinatura!")]
        [StringLength(80, ErrorMessage = "O nome da assinatura deve conter até 80 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome da assinatura deve conter no mínimo 5 caracteres!")]
        [DisplayName("Título:")]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        //[GreaterThanToday]
        [DisplayName("Data início:")]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.DateTime)]
        //[GreaterThanToday]
        [DisplayName("Data término:")]
        public DateTime DataFim { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Cliente inválido!")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
