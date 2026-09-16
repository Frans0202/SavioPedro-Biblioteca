using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("emprestimos"), PrimaryKey(nameof(Id))]
    public class Emprestimo
    {
        [Column("id_emp")]
        public int Id { get; set; }

        [Column("usuario_id_emp")]
        public int UsuarioId { get; set; }

        [Column("livro_id_emp")]
        public int LivroId { get; set; }

        [Column("data_emprestimo_emp")]
        public DateOnly DataEmprestimo { get; set; }

        [Column("data_prevista_devolucao_emp")]
        public DateOnly DataPrevistaDevolucao { get; set; }

        [Column("data_efetiva_devolucao_emp")]
        public DateOnly? DataEfetivaDevolucao { get; set; }

        [Column("valor_multa_emp")]
        public decimal ValorMulta { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public Livro Livro { get; set; } = null!;
    }
}