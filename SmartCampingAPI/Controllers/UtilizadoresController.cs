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
    public class UtilizadoresController : Controller
    {
        private readonly IUtilizadorRepository _utilizadorRepository;
        private readonly IMapper _mapper;

        public UtilizadoresController(IUtilizadorRepository utilizadorRepository, IMapper mapper)
        {
            _utilizadorRepository = utilizadorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Utilizador>))] // Not actually needed
        public IActionResult GetUtilizadores()
        {
            var utilizadores = _mapper.Map<List<UtilizadorDto>>
                (_utilizadorRepository.GetUtilizadores());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(utilizadores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Utilizador))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetUtilizador(int id)
        {
            if (!_utilizadorRepository.UtilizadorExists(id))
                return NotFound();

            var utilizador = _mapper.Map<UtilizadorDto>
                (_utilizadorRepository.GetUtilizador(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(utilizador);
        }
    }

}
