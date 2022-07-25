using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {   
        private readonly IProdutoRepository _produtosRepository;
        private readonly IMapper _mapper;

        public ProdutoController(
            IProdutoRepository produtosRepository,
            IMapper mapper)
        {
            _produtosRepository = produtosRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoDto>))]
        public IActionResult getALL(){

            var produtos = _mapper.Map<ICollection<ProdutoDto>>(_produtosRepository.getALL());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produtos);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(ProdutoDto))]
        [ProducesResponseType(400)]
        public IActionResult get(int Id)
        {
            if (!_produtosRepository.Exists(Id))
                return NotFound();
            var pedido = _produtosRepository.get(Id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] ProdutoDto produtoCreate)
        {

            if (produtoCreate == null)
                return BadRequest(ModelState);

            var produtoMap = _mapper.Map<Produto>(produtoCreate);

            if (!_produtosRepository.Create(produtoMap))
            {
                ModelState.AddModelError("", "Algo deu errado ao salvar");
                return StatusCode(500, ModelState);
            }

            return Ok("Criado com sucesso");
        }


        [HttpPut("{pedidoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update(int pedidoId, [FromBody] ProdutoDto pedidoUpdate)
        {
            if (pedidoUpdate == null)
                return BadRequest(ModelState);

            if (pedidoId != pedidoUpdate.Id)
                return BadRequest(ModelState);

            if (!_produtosRepository.Exists(pedidoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var produtoMap = _mapper.Map<Produto>(pedidoUpdate);

            if (!_produtosRepository.Update(produtoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{pedidoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int pedidoId)
        {
            if (!_produtosRepository.Exists(pedidoId))
            {
                return NotFound();
            }

            if (!_produtosRepository.Delete(pedidoId))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}