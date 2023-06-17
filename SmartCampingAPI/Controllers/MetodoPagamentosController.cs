using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCamping.Filter;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;
using SmartCampingAPI.Repository;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class MetodoPagamentosController : ControllerBase
    {
        private readonly IMetodoPagamentoRepository _metodoPagamentoRepository;
        private readonly IMapper _mapper;

        public MetodoPagamentosController(IMetodoPagamentoRepository metodoPagamentoRepository, IMapper mapper)
        {
            _metodoPagamentoRepository = metodoPagamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MetodoPagamento>))] // Not actually needed
        public IActionResult GetMetodoPagamentos()
        {
            var metodos = _mapper.Map<List<MetodoPagamentoDto>>
                (_metodoPagamentoRepository.GetMetodoPagamentos());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(metodos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MetodoPagamento))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetAlojamento(int id)
        {
            if (!_metodoPagamentoRepository.MetodoPagamentoExists(id))
                return NotFound();

            var metodos = _mapper.Map<MetodoPagamentoDto>
                (_metodoPagamentoRepository.GetMetodoPagamento(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(metodos);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarMetodoPagamento([FromBody] MetodoPagamentoDto metodoPagamentoCriar)
        {
            if (metodoPagamentoCriar == null)
                return BadRequest();

            var metodoPagamento = _metodoPagamentoRepository.GetMetodoPagamentos()
                .Where(m => m.Metodo.Trim().ToUpper() == metodoPagamentoCriar.Metodo.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (metodoPagamento != null)
            {
                ModelState.AddModelError("", "O Metodo de Pagamento já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var metodoPagamentoMap = _mapper.Map<MetodoPagamento>(metodoPagamentoCriar);

            if (!_metodoPagamentoRepository.CriarMetodoPagamento(metodoPagamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Método de pagamento criado com sucesso!");
        }

        [HttpPut("{metodoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMetodoPagamento(int metodoId, [FromBody] MetodoPagamentoDto metodoAtualizado)
        {
            if (metodoAtualizado == null)
                return BadRequest(ModelState);

            if (metodoId != metodoAtualizado.MetodoPagamentoId)
                return BadRequest(ModelState);

            if (!_metodoPagamentoRepository.MetodoPagamentoExists(metodoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var metodoPagamentoMap = _mapper.Map<MetodoPagamento>(metodoAtualizado);

            if (!_metodoPagamentoRepository.AtualizarMetodoPagamento(metodoPagamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
