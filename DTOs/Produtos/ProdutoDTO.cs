using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, 1000, ErrorMessage = "A quantidade deve ser entre 0 e 1000")]
        public int QuantidadeEstoque { get; set; }
        public TipoProduto TipoProduto { get; set; } = TipoProduto.BoloComum;
        public DateTime? DataValidade { get; set; }
        public bool Ativo { get; set; } = true;
    }
}