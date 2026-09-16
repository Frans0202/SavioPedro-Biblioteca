using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class LivroDto
    {
        [Required]
        public required string Titulo { get; set; }

        [Required]
        public required string Isbn { get; set; }

        [Required]
        public required string Editora { get; set; }

        [Required]
        public int AnoPublicacao { get; set; }

        [Required]
        public required string Genero { get; set; }

        [Required]
        public int QuantidadeTotalExemplares { get; set; }

        [Required]
        public int QuantidadeDisponivel { get; set; }

        public List<int> AutoresIds { get; set; } = new();
    }
}