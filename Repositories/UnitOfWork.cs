using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBolosApi.Context;

namespace MbolosApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProdutoRepository? _produtoRepo;

        private IPedidosRepository? _pedidosRepo;
        private IClienteRepository? _clienteRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            { return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context); }
        }

        public IPedidosRepository PedidosRepository
        {
            get { return _pedidosRepo = _pedidosRepo ?? new PedidoRepository(_context); }
        }

        public IClienteRepository ClienteRepository
        {
            get { return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context); }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}