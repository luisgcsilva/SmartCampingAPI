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
    [TokenFilter]
    public class AlojamentosController : ControllerBase
    {
        private readonly IAlojamentoRepository _alojamentoRepository;
        private readonly IMapper _mapper;

        public AlojamentosController(IAlojamentoRepository IAlojamentoRepository, IMapper mapper)
        {
            _alojamentoRepository = IAlojamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Alojamento>))] // Not actually needed
        public IActionResult GetAlojamentos()
        {
            var alojamentos = _mapper.Map<List<AlojamentoDto>>
                (_alojamentoRepository.GetAlojamentos());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(alojamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Alojamento))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetAlojamento(int id)
        {
            if (!_alojamentoRepository.AlojamentoExists(id))
                return NotFound();

            var alojamento = _mapper.Map<AlojamentoDto>
                (_alojamentoRepository.GetAlojamento(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(alojamento);
        }

        [HttpGet("reservas/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reserva>))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetReservasPorAlojamento(int id)
        {
            var reservas = _alojamentoRepository.GetReservasPorAlojamento(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservas);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarAlojamento([FromBody] AlojamentoDto alojamentoCriar)
        {
            if (alojamentoCriar == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest();

            var alojamentoMap = _mapper.Map<Alojamento>(alojamentoCriar);

            if (!_alojamentoRepository.CriarAlojamento(alojamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Alojamento criado com sucesso!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PutAlojamento([FromBody] AlojamentoDto alojamentoAtualizado)
        {
            if (alojamentoAtualizado == null)
                return BadRequest(ModelState);

            if(!_alojamentoRepository.AlojamentoExists(alojamentoAtualizado.AlojamentoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var alojamentoMap = _mapper.Map<Alojamento>(alojamentoAtualizado);

            if(!_alojamentoRepository.AtualizarAlojamento(alojamentoMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
