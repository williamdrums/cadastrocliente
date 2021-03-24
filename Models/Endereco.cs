using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Logradouro")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracters")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracters")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Bairro")]
        [MaxLength(40, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Numero Residência")]
        [MaxLength(5, ErrorMessage = "Este campo deve conter entre 1 e 5 caracters")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 5 caracters")]
        public int numero { get; set; }

        public Cidade IdCidade { get; set; }
    }
}