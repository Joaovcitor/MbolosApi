using MbolosApi.Interfaces;
using MbolosApi.Repositories;
using MBolosApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MBolosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IPasswordService _passwordService;

        public ClientController(IUnitOfWork uof, IPasswordService passwordService)
        {
            _uof = uof;
            _passwordService = passwordService;
        }

        [HttpGet("{id:int}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _uof.ClienteRepository.GetAsync(p => p.Id == id);
            if (cliente == null) return BadRequest("Cliente não encontrado!");
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(Cliente cliente)
        {
            if (cliente == null) return BadRequest("Dados inválidos");

            cliente.SenhaHash = _passwordService.PasswordHash(cliente.SenhaHash);

            var clienteCriado = _uof.ClienteRepository.Create(cliente);
            await _uof.CommitAsync();
            return new CreatedAtRouteResult("GetCliente", new { id = cliente.Id }, clienteCriado);
        }
    }
}