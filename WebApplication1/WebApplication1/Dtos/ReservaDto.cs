using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class ReservaDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int LivroId { get; set; }

        [Required]
        public int PosicaoFila { get; set; }

        [Required]
        public DateTime DataExpiracao { get; set; }

        public string Status { get; set; } = "Pendente";
    }
}