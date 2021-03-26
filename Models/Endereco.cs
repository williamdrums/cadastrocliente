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

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Numero Residência")]
        [Range(1, int.MaxValue, ErrorMessage = "Numero Inválido")]
        public int numero { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Id Cidade")]
        [Range(1, int.MaxValue, ErrorMessage = "Cidade Inválida")]
        public int IdCidade { get; set; }

        public Cidade Cidade { get; set; }
    }
}