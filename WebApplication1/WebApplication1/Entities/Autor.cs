using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("autores"), PrimaryKey(nameof(Id))]
    public class Autor
    {
        [Column("id_aut")]
        public int Id { get; set; }


        [Column("nome_aut")]
        public string Nome { get; set; } = string.Empty;

        [Column("nacionalidade_aut")]
        public string Nacionalidade { get; set; } = string.Empty;

        [Column("data_nascimento_aut")]
        public DateOnly DataNascimento { get; set; }

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}