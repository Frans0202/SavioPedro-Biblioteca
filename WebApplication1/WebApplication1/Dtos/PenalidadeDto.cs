using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class PenalidadeDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int EmprestimoId { get; set; }

        [Required]
        public int DiasAtraso { get; set; }

        [Required]
        public decimal ValorMulta { get; set; }

        public string StatusPagamento { get; set; } = "Pendente";
    }
}