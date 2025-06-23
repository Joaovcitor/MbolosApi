using MbolosApi.Pagination;
using MBolosApi.Context;
using MBolosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MbolosApi.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        // public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParameters)
        // {
        //     return GetAll().OrderBy(p => p.Nome).Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize).Take(produtosParameters.PageSize).ToList();
        // }

        public async Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters)
        {
            var produtos = await GetAllAsync();
            var produtosOrdenados = produtos.OrderBy(p => p.Id).AsQueryable();
            var resultados = PagedList<Produto>.ToPagedList(produtosOrdenados, produtosParameters.PageNumber, produtosParameters.PageSize);
            return resultados;
        }
    }
}