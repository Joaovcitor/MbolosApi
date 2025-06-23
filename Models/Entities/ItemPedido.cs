using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MBolosApi.Models;
using MBolosApi.Models.Entities;

namespace MbolosApi.Models.Entities
{
    [Table("item_pedido")]
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PedidoId { get; set; }
        [JsonIgnore]
        public Pedidos Pedido { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}