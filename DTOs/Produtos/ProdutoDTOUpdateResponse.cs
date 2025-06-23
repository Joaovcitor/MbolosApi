using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbolosApi.Enums;

namespace MbolosApi.DTOs.Produtos
{
    public class ProdutoDTOUpdateResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public TipoProduto TipoProduto { get; set; } = TipoProduto.BoloComum;

        public DateTime? DataValidade { get; set; }
        public bool Ativo { get; set; } = true;
    }
}