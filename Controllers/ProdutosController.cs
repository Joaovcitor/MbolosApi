using MbolosApi.Repositories;
using MBolosApi.Context;
using MBolosApi.Models;
using MBolosApi.Models.DTOs;
using MbolosApi.DTOs.Mappings;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MbolosApi.DTOs.Produtos;
using Microsoft.AspNetCore.JsonPatch;

namespace MBolosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ProdutosController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> GetAsync()
        {
            var produtos = _uof.ProdutoRepository.GetAll();
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
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

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }
        [HttpPost]
        public ActionResult<ProdutoDTO> PostAsync(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            var produtoCriado = _uof.ProdutoRepository.Create(produto);
            _uof.Commit();
            var novoProdutoDTO = _mapper.Map<ProdutoDTO>(produtoCriado);
            return new CreatedAtRouteResult("GetByIdAsync", new { id = novoProdutoDTO.Id }, novoProdutoDTO);
        }

        [HttpPatch("{id}/UpdatePartial")]
        public ActionResult<ProdutoDTOUpdateResponse> Patch(int id, JsonPatchDocument<ProdutoDTOUpdateRequest> patchProdutoDto)
        {
            if (patchProdutoDto is null || id <= 0) return BadRequest();

            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);
            if (produto == null) return NotFound();
            var produtoUpdateRequest = _mapper.Map<ProdutoDTOUpdateRequest>(produto);

            patchProdutoDto.ApplyTo(produtoUpdateRequest, ModelState);
            if (!ModelState.IsValid || !TryValidateModel(produtoUpdateRequest))
                return BadRequest(ModelState);

            _mapper.Map(produtoUpdateRequest, produto);
            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok(_mapper.Map<ProdutoDTOUpdateResponse>(produto));
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