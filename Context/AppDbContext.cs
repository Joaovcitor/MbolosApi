using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBolosApi.Models;
using MBolosApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MBolosApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}