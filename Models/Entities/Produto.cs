using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBolosApi.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 1000, ErrorMessage = "O preço deve estar entre R$0,01 e R$1.000,00")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória!")]
        [Range(0, 1000, ErrorMessage = "A quantidade deve ser entre 0 e 1000")]
        [Column("quantidade_estoque")]
        public int QuantidadeEstoque { get; set; }


        [StringLength(50)]
        [Column("tipo_produto")]
        public string TipoProduto { get; set; } = "Padaria";

        [Column("data_validade", TypeName = "date")]
        public DateTime? DataValidade { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;
    }
}