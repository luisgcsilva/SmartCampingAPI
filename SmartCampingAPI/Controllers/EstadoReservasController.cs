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
    public class EstadoReservasController : ControllerBase
    {
        private readonly IEstadoReservaRepository _estadoReservaRepository;
        private readonly IMapper _mapper;

        public EstadoReservasController(IEstadoReservaRepository estadoReservaRepository, IMapper mapper)
        {
            _estadoReservaRepository = estadoReservaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EstadoReserva>))] // Not actually needed
        public IActionResult GetEstadoReservas()
        {
            var estadoReservas = _mapper.Map<List<EstadoReservaDto>>
                (_estadoReservaRepository.GetEstadoReservas());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(estadoReservas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EstadoReserva))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetEstadoReserva(int id)
        {
            if (!_estadoReservaRepository.EstadoReservaExists(id))
                return NotFound();

            var estadoReserva = _mapper.Map<EstadoReservaDto>
                (_estadoReservaRepository.GetEstadoReserva(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(estadoReserva);
        }

        [HttpGet("reservas/{estadoId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reserva>))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetReservasPorEstado(int estadoId)
        {
            var reservas = _estadoReservaRepository.GetReservasPorEstado(estadoId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservas);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarEstadoReserva([FromBody] EstadoReservaDto estadoReservaCriar)
        {
            if (estadoReservaCriar == null)
                return BadRequest();

            var estadoReserva = _estadoReservaRepository.GetEstadoReservas()
                .Where(e => e.Estado.Trim().ToUpper() == estadoReservaCriar.Estado.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (estadoReserva != null)
            {
                ModelState.AddModelError("", "O estado de reserva já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var estadoReservaMap = _mapper.Map<EstadoReserva>(estadoReservaCriar);

            if (!_estadoReservaRepository.CriarEstadoReserva(estadoReservaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Estado de Reserva criado com sucesso!");
        }

        [HttpPut("{estadoReservaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEstadoReserva(int estadoReservaId, [FromBody] EstadoReservaDto estadoReservaAtualizado)
        {
            if (estadoReservaAtualizado == null)
                return BadRequest(ModelState);

            if (estadoReservaId != estadoReservaAtualizado.EstadoReservaId)
                return BadRequest(ModelState);

            if (!_estadoReservaRepository.EstadoReservaExists(estadoReservaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var estadoReservaMap = _mapper.Map<EstadoReserva>(estadoReservaAtualizado);

            if (!_estadoReservaRepository.AtualizarEstadoReserva(estadoReservaMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
