using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var tipoAlojamentos = _tipoAlojamentoRepository.GetTipoAlojamentos();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(tipoAlojamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TipoAlojamento))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetUtilizador(int id)
        {
            if (!_tipoAlojamentoRepository.TipoAlojamentoExists(id))
                return NotFound();

            var reserva = _tipoAlojamentoRepository.GetTipoAlojamento(id);

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
    }
}
