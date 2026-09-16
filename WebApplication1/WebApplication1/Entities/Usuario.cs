using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    [Table("usuarios"), PrimaryKey(nameof(Id))]
    public class Usuario
    {
        [Column("id_usu")]
        public int Id { get; set; }

        [Column("nome_usu")]
        public string Nome { get; set; } = string.Empty;

        [Column("cpf_usu")]
        public string Cpf { get; set; } = string.Empty;

        [Column("data_nascimento_usu")]
        public DateOnly DataNascimento { get; set; }

        [Column("telefone_usu")]
        public string Telefone { get; set; } = string.Empty;

        [Column("email_usu")]
        public string Email { get; set; } = string.Empty;

        [Column("endereco_usu")]
        public string Endereco { get; set; } = string.Empty;
    }
}