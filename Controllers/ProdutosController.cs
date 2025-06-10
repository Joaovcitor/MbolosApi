using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBolosApi.Context;
using MBolosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBolosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetByIdAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Não foi possível encontrar o produto.");
            }

            return produto;
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> PostAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAsync", new { id = produto.Id }, produto);
        }
    }
}