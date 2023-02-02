using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

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
    }
}
