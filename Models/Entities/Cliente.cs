using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBolosApi.Models.Entities
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nome é obrigatório!")]
        [Column("nome")]
        public string? Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(150, ErrorMessage = "Email é orbigatório!")]
        public string? Email { get; set; }
        [Required]
        [Column("senha_hash")]
        public string? SenhaHash { get; set; }

    }
}