using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.Repositories
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        IPedidosRepository PedidosRepository { get; }

        void Commit();
    }
}