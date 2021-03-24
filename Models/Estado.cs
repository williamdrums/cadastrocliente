
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Nome Estado")]
        [MaxLength(40, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Unidade Federativa")]
        [MaxLength(2, ErrorMessage = "Este campo deve conter 2 caracters")]
        [MinLength(2, ErrorMessage = "Este campo deve conter 2 caracters")]
        public string Uf { get; set; }
    }
}