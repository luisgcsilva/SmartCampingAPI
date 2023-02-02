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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarUtilizador([FromBody] UtilizadorDto utilizadorCriar)
        {
            if (utilizadorCriar == null)
                return BadRequest();

            var utilizador = _utilizadorRepository.GetUtilizadores()
                .Where(u => u.Email.Trim().ToUpper() == utilizadorCriar.Email.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(utilizador != null)
            {
                ModelState.AddModelError("", "O utilizador já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var utilizadorMap = _mapper.Map<Utilizador>(utilizadorCriar);

            if(!_utilizadorRepository.CriarUtilizador(utilizadorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Utilizador criado com sucesso!");
        }

        [HttpPut("{utilizadorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUtilizador(int utilizadorId, [FromBody] UtilizadorDto utilizadorAtualizado)
        {
            if (utilizadorAtualizado == null)
                return BadRequest(ModelState);

            if (utilizadorId != utilizadorAtualizado.UtilizadorId)
                return BadRequest(ModelState);

            if (!_utilizadorRepository.UtilizadorExists(utilizadorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var utilizadorMap = _mapper.Map<Utilizador>(utilizadorAtualizado);

            if (!_utilizadorRepository.AtualizarUtilizador(utilizadorMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }

}
