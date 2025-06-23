using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbolosApi.Repositories;
using MBolosApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MBolosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public PedidosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet(Name = "GetPedido")]
        public async Task<ActionResult<IEnumerable<Pedidos>>> Get()
        {
            var pedidos = await _uof.PedidosRepository.GetAllAsync();
            return Ok(pedidos);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedidos>> GetById(int id)
        {
            var pedido = await _uof.PedidosRepository.GetAsync(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound("Não foi possível encontrar o pedido");
            }
            return Ok(pedido);
        }
        [HttpPost]

        public async Task<ActionResult<Pedidos>> Post(Pedidos pedidos)
        {
            if (pedidos == null)
            {
                return BadRequest("Dados inválidos!");
            }

            var pedido = _uof.PedidosRepository.Create(pedidos);
            await _uof.CommitAsync();
            return new CreatedAtRouteResult("GetPedido", new { id = pedidos.Id }, pedido);
        }

        // verei como será usado o metodo Update
    }
}