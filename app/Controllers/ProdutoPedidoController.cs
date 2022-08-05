using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoPedidoController : ControllerBase
    {   
        private readonly IProdutoRepository _produtosRepository;
        private readonly IMapper _mapper;

        public ProdutoPedidoController(
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


        [HttpPut("{produtoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update(int produtoId, [FromBody] ProdutoDto produtoUpdate)
        {

            if (!_produtosRepository.Exists(produtoId))
                return NotFound();

            var produtoMap = _mapper.Map<Produto>(produtoUpdate);

            produtoMap.Id = produtoId;

            if (!_produtosRepository.Update(produtoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{produtoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int produtoId)
        {
            if (!_produtosRepository.Exists(produtoId))
            {
                return NotFound();
            }

            if (!_produtosRepository.Delete(produtoId))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}