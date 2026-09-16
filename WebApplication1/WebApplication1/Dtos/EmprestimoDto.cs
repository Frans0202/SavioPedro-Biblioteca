using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class EmprestimoDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int LivroId { get; set; }

        [Required]
        public DateOnly DataEmprestimo { get; set; }

        [Required]
        public DateOnly DataPrevistaDevolucao { get; set; }

        public DateOnly? DataEfetivaDevolucao { get; set; }

        public decimal ValorMulta { get; set; }
    }
}