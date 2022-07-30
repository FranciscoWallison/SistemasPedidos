using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {   
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public PedidoController(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PedidoDto>))]
        public IActionResult getALL(){

            var produtos = _mapper.Map<ICollection<PedidoDto>>(_pedidoRepository.getALL());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produtos);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(PedidoDto))]
        [ProducesResponseType(400)]
        public IActionResult get(int Id)
        {
            if (!_pedidoRepository.Exists(Id))
                return NotFound();

            // var pedido = _mapper.Map<PedidoDto>(_pedidoRepository.get(Id));
            var pedido = _pedidoRepository.get(Id);

            // pedido.Produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.getProduto(pedido.Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] PedidoDto pedidoCreate)
        {

            if (pedidoCreate == null)
                return BadRequest(ModelState);

            var pedidoMap = _mapper.Map<Pedido>(pedidoCreate);
            // var produtosMap = _mapper.Map<List<Produto>>(produtos);
            
            List<Produto> produtos = new List<Produto>();
            foreach (ProdutoDto produto in pedidoCreate.Produtos)
            {
                // validar se existe os produtos                
                produtos.Add(_mapper.Map<Produto>(produto));
            }

            if (!_pedidoRepository.Create(pedidoMap.FornecedorId, produtos, pedidoMap))
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
        public IActionResult Update(int pedidoId, [FromBody] PedidoDto pedidoUpdate)
        {
            if (pedidoUpdate == null)
                return BadRequest(ModelState);

            if (pedidoId != pedidoUpdate.Id)
                return BadRequest(ModelState);

            if (!_pedidoRepository.Exists(pedidoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var peidoMap = _mapper.Map<Pedido>(pedidoUpdate);

            if (!_pedidoRepository.Update(peidoMap))
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
            if (!_pedidoRepository.Exists(pedidoId))
            {
                return NotFound();
            }

            if (!_pedidoRepository.Delete(pedidoId))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}