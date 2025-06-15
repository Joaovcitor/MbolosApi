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
    }
}