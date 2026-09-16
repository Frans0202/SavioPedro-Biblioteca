using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'cpf' é obrigatório")]
        public required string Cpf { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        [Required]
        public required string Telefone { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Endereco { get; set; }
    }
}