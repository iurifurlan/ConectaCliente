using System.ComponentModel.DataAnnotations;

namespace ConectaCliente.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Foto do Cliente")]
        public byte[] FotoCliente { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome tem que possuir no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(50, ErrorMessage = "O e-mail tem que possuir no máximo 50 caracteres.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(15, ErrorMessage = "O sexo tem que possuir no máximo 15 caracteres.")]
        public string Sexo { get; set; }        

        [Required]
        [StringLength(150, ErrorMessage = "Logradouro deve possuir no máximo 150 caracteres.")]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Complemento deve possuir no máximo 30 caracteres.")]
        public string Complemento { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Bairro deve possuir no máximo 50 caracteres.")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "O estado deve possuir 2 caracteres.")]
        public string Estado { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        public string CEP { get; set; }

    }
}
   
