using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBolosApi.Models;
using MBolosApi.Models.DTOs;

namespace MbolosApi.DTOs.Mappings
{
    public static class ProdutoDTOMappingExtensions
    {
        public static ProdutoDTO? ToProdutoDTO(this Produto produto)
        {
            if (produto == null) return null;

            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                DataValidade = produto.DataValidade,
                Preco = produto.Preco,
                TipoProduto = produto.TipoProduto,

            };
        }

        public static Produto? ToProduto(this ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null) return null;
            return new Produto
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                DataValidade = produtoDTO.DataValidade,
                Preco = produtoDTO.Preco,
                TipoProduto = produtoDTO.TipoProduto,
            };
        }

        public static IEnumerable<ProdutoDTO> ToProdutoDTOList(this IEnumerable<Produto> produtos)
        {
            if (produtos == null || !produtos.Any()) return new List<ProdutoDTO>();

            return produtos.Select(produto => new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                DataValidade = produto.DataValidade,
                Preco = produto.Preco,
                TipoProduto = produto.TipoProduto,
            });
        }
    }
}