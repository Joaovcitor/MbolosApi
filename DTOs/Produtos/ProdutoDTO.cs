using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbolosApi.Enums;

namespace MBolosApi.Models.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public TipoProduto TipoProduto { get; set; } = TipoProduto.BoloComum;
        public DateTime? DataValidade { get; set; }
    }
}