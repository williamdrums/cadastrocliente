
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Nome Cidade")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracters")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3  e 50 caracters")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Id Estado")]
        [Range(1, int.MaxValue, ErrorMessage = "Estado Inválida")]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
    }
}