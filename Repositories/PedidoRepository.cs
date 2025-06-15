using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBolosApi.Context;
using MBolosApi.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MbolosApi.Repositories
{
    public class PedidoRepository : Repository<Pedidos>, IPedidosRepository
    {

        public PedidoRepository(AppDbContext context) : base(context)
        {
        }
    }
}