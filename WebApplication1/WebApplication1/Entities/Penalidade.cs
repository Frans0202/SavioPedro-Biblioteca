using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("penalidades"), PrimaryKey(nameof(Id))]
    public class Penalidade
    {
        [Column("id_pen")]
        public int Id { get; set; }

        [Column("usuario_id_pen")]
        public int UsuarioId { get; set; }

        [Column("emprestimo_id_pen")]
        public int EmprestimoId { get; set; }

        [Column("data_pen")]
        public DateTime DataPenalidade { get; set; } = DateTime.Now;

        [Column("dias_atraso_pen")]
        public int DiasAtraso { get; set; }

        [Column("valor_multa_pen")]
        public decimal ValorMulta { get; set; }

        [Column("status_pagamento_pen")]
        public string StatusPagamento { get; set; } = "Pendente";

        public Usuario Usuario { get; set; } = null!;

        public Emprestimo Emprestimo { get; set; } = null!;
    }
}