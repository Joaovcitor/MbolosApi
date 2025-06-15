using MbolosApi.Repositories;
using MBolosApi.Context;
using MBolosApi.Models;
using MBolosApi.Models.DTOs;
using MbolosApi.DTOs.Mappings;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBolosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public ProdutosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> GetAsync()
        {
            var produtos = _uof.ProdutoRepository.GetAll();
            var produtosDto = produtos.ToProdutoDTOList();
            return Ok(produtosDto);
        }

        [HttpGet("{id:int}", Name = "GetByIdAsync")]
        public ActionResult<ProdutoDTO> GetByIdAsync(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);
            if (produto == null)
            {
                return NotFound("Não foi possível encontrar o produto.");
            }

            var produtoDTO = produto.ToProdutoDTO();

            return Ok(produtoDTO);
        }
        [HttpPost]
        public ActionResult<ProdutoDTO> PostAsync(ProdutoDTO produtoDTO)
        {
            var produto = produtoDTO.ToProduto();
            var produtoCriado = _uof.ProdutoRepository.Create(produto);
            _uof.Commit();
            var novoProdutoDTO = produtoCriado.ToProdutoDTO();
            return new CreatedAtRouteResult("GetByIdAsync", new { id = novoProdutoDTO.Id }, novoProdutoDTO);
        }
        [HttpPut("{id:int}")]
        public ActionResult<ProdutoDTO> PutAsync(int id, ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id) return BadRequest("Id não existe!");
            var produto = produtoDto.ToProduto();
            var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            var produtoAtualizadoDTO = produtoAtualizado.ToProdutoDTO();
            return Ok(produtoAtualizadoDTO);
        }

        // será necessário um método delete nesse crud? Quais usuários vão fazer tal operação?
    }
}