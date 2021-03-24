using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Nome Cliente")]
        [MaxLength(40, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracters")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Cpf")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracters")]
        [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracters")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Numero Telefone")]
        [Phone]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        public Endereco IdEndereco { get; set; }

    }
}