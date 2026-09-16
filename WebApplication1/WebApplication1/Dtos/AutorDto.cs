using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class AutorDto
    {
        [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
        public required string Nome { get; set; }

        [Required]
        public required string Nacionalidade { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }
    }
}