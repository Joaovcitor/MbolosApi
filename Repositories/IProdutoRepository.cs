using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbolosApi.Pagination;
using MBolosApi.Models;

namespace MbolosApi.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters);
    }
}