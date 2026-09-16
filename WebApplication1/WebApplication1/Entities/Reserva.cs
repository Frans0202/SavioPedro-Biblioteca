using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("reservas"), PrimaryKey(nameof(Id))]
    public class Reserva
    {
        [Column("id_res")]
        public int Id { get; set; }

        [Column("usuario_id_res")]
        public int UsuarioId { get; set; }

        [Column("livro_id_res")]
        public int LivroId { get; set; }

        [Column("data_reserva_res")]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        [Column("posicao_fila_res")]
        public int PosicaoFila { get; set; }

        [Column("data_expiracao_res")]
        public DateTime DataExpiracao { get; set; }

        [Column("status_res")]
        public string Status { get; set; } = "Pendente";

        public Usuario Usuario { get; set; } = null!;

        public Livro Livro { get; set; } = null!;
    }
}