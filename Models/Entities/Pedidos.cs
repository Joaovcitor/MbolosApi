using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbolosApi.Enums;
using MbolosApi.Models.Entities;

namespace MBolosApi.Models.Entities
{
    [Table("pedido")]
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
        [Required]
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        [Required]
        public StatusPedido StatusPedido { get; set; } = StatusPedido.Processando;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        [MaxLength(200), MinLength(0)]
        public string EnderecoEntrega { get; set; }
    }
}