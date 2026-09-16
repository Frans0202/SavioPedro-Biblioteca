using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("livros"), PrimaryKey(nameof(Id))]
    public class Livro
    {
        [Column("id_liv")]
        public int Id { get; set; }

        [Column("titulo_liv")]
        public string Titulo { get; set; } = string.Empty;

        [Column("isbn_liv")]
        public string Isbn { get; set; } = string.Empty;

        [Column("editora_liv")]
        public string Editora { get; set; } = string.Empty;

        [Column("ano_publicacao_liv")]
        public int AnoPublicacao { get; set; }

        [Column("genero_liv")]
        public string Genero { get; set; } = string.Empty;

        [Column("quantidade_total_liv")]
        public int QuantidadeTotalExemplares { get; set; }

        [Column("quantidade_disponivel_liv")]
        public int QuantidadeDisponivel { get; set; }

        public ICollection<Autor> Autores { get; set; } = new List<Autor>();

        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}