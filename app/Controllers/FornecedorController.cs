using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {   
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorController(
            IFornecedorRepository fornecedorRepository,
            IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FornecedorDto>))]
        public IActionResult getALL(){

            var produtos = _mapper.Map<ICollection<FornecedorDto>>(_fornecedorRepository.getALL());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produtos);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(FornecedorDto))]
        [ProducesResponseType(400)]
        public IActionResult get(int Id)
        {
            if (!_fornecedorRepository.Exists(Id))
                return NotFound();
            var pedido = _fornecedorRepository.get(Id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] FornecedorDto fornecedorCreate)
        {

            if (fornecedorCreate == null)
                return BadRequest(ModelState);

            var pedidoMap = _mapper.Map<Fornecedor>(fornecedorCreate);

            if (!_fornecedorRepository.Create(pedidoMap))
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
        public IActionResult Update(int pedidoId, [FromBody] FornecedorDto pedidoUpdate)
        {
            if (pedidoUpdate == null)
                return BadRequest(ModelState);

            if (pedidoId != pedidoUpdate.Id)
                return BadRequest(ModelState);

            if (!_fornecedorRepository.Exists(pedidoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var fornecedorMap = _mapper.Map<Fornecedor>(pedidoUpdate);

            if (!_fornecedorRepository.Update(fornecedorMap))
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
            if (!_fornecedorRepository.Exists(pedidoId))
            {
                return NotFound();
            }

            if (!_fornecedorRepository.Delete(pedidoId))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}