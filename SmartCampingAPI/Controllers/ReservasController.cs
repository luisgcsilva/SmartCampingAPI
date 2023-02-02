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
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public ReservasController(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reserva>))] // Not actually needed
        public IActionResult GetReservas()
        {
            var reservas = _reservaRepository.GetReservas();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Reserva))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetUtilizador(int id)
        {
            if (!_reservaRepository.ReservaExists(id))
                return NotFound();

            var reserva = _reservaRepository.GetReserva(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reserva);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarReserva([FromBody] ReservaDto reservaCriar)
        {
            if (reservaCriar == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var reservaMap = _mapper.Map<Reserva>(reservaCriar);

            if (!_reservaRepository.CriarReserva(reservaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Reserva criada com sucesso!");
        }

        [HttpPut("{reservaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReserva(int reservaId, [FromBody] ReservaDto reservaAtualizada)
        {
            if (reservaAtualizada == null)
                return BadRequest(ModelState);

            if (reservaId != reservaAtualizada.ReservaId)
                return BadRequest(ModelState);

            if (!_reservaRepository.ReservaExists(reservaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var reservaMap = _mapper.Map<Reserva>(reservaAtualizada);

            if (!_reservaRepository.AtualizarReserva(reservaMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
