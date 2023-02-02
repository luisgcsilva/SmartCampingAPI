using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;
using SmartCampingAPI.Repository;

namespace SmartCampingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlojamentosController : Controller
    {
        private readonly ITipoAlojamentoRepository _tipoAlojamentoRepository;
        private readonly IMapper _mapper;

        public TipoAlojamentosController(ITipoAlojamentoRepository tipoAlojamentoRepository, IMapper mapper)
        {
            _tipoAlojamentoRepository = tipoAlojamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipoAlojamento>))] // Not actually needed
        public IActionResult GetTipoAlojamentos()
        {
            var tipoAlojamentos = 
               _mapper.Map<TipoAlojamentoDto>(_tipoAlojamentoRepository.GetTipoAlojamentos());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(tipoAlojamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TipoAlojamento))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetTipoAlojamento(int id)
        {
            if (!_tipoAlojamentoRepository.TipoAlojamentoExists(id))
                return NotFound();

            var reserva = 
                _mapper.Map<TipoAlojamentoDto>(_tipoAlojamentoRepository.GetTipoAlojamento(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reserva);
        }

        [HttpGet("reservas/{tipoAlojamentoId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reserva>))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetReservasPorTipoAlojamento(int tipoAlojamentoId)
        {
            var reservas = _tipoAlojamentoRepository.GetReservasPorTipoAlojamento(tipoAlojamentoId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservas);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarTipoAlojamento([FromBody] TipoAlojamentoDto tipoAlojamentoCriar)
        {
            if (tipoAlojamentoCriar == null)
                return BadRequest();

            var tipoAlojamento = _tipoAlojamentoRepository.GetTipoAlojamentos()
                .Where(u => u.Tipo.Trim().ToUpper() == tipoAlojamentoCriar.Tipo.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (tipoAlojamento != null)
            {
                ModelState.AddModelError("", "O tipo de alojamento já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var tipoAlojamentoMap = _mapper.Map<TipoAlojamento>(tipoAlojamentoCriar);

            if (!_tipoAlojamentoRepository.CriarTipoAlojamento(tipoAlojamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Tipo de Alojamento criado com sucesso!");
        }

        [HttpPut("{tipoAlojamentoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAlojamento(int tipoAlojamentoId, [FromBody] TipoAlojamentoDto tipoAlojamentoAtualizado)
        {
            if (tipoAlojamentoAtualizado == null)
                return BadRequest(ModelState);

            if (tipoAlojamentoId != tipoAlojamentoAtualizado.TipoAlojamentoId)
                return BadRequest(ModelState);

            if (!_tipoAlojamentoRepository.TipoAlojamentoExists(tipoAlojamentoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var tipoAlojamentoMap = _mapper.Map<TipoAlojamento>(tipoAlojamentoAtualizado);

            if (!_tipoAlojamentoRepository.AtualizarTipoAlojamento(tipoAlojamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
