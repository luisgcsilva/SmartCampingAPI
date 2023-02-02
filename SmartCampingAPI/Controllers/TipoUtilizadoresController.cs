using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampingAPI.Data;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;
using SmartCampingAPI.Repository;

namespace SmartCampingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUtilizadoresController : ControllerBase
    {
        private readonly ITipoUtilizadorRepository _tipoUtilizadorRepository;
        private readonly IMapper _mapper;

        public TipoUtilizadoresController(ITipoUtilizadorRepository tipoUtilizadorRepository, IMapper mapper)
        {
            _tipoUtilizadorRepository = tipoUtilizadorRepository;
            _mapper = mapper;
        }

        // GET: api/TipoUtilizadores
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipoUtilizador>))] // Not actually needed
        public IActionResult GetTipoUtilizadores()
        {
            var tipoUtilizadores = _mapper.Map<List<TipoUtilizadorDto>>
                (_tipoUtilizadorRepository.GetTipoUtilizadores());

            if(!ModelState.IsValid)
                return BadRequest();
            
            return Ok(tipoUtilizadores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,  Type = typeof(TipoUtilizador))]
        [ProducesResponseType(400)]
        public IActionResult GetTipoUtilizador(int id)
        {
            if(!_tipoUtilizadorRepository.TipoUtilizadorExists(id))
                return NotFound();

            var tipoUtilizador = _mapper.Map<TipoUtilizadorDto>
                (_tipoUtilizadorRepository.GetTipoUtilizador(id));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(tipoUtilizador);
        }

        [HttpGet("utilizadores/{tipoUtilizadorId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Utilizador>))]
        [ProducesResponseType(400)]
        public IActionResult GetUtilizadoresPorTipo(int tipoUtilizadorId)
        {
            var utilizadores = _mapper.Map<List<UtilizadorDto>>
                (_tipoUtilizadorRepository.GetUtilizadoresPorTipo(tipoUtilizadorId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(utilizadores);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarTipoUtilizador([FromBody] TipoUtilizadorDto tipoUtilizadorCriar)
        {
            if (tipoUtilizadorCriar == null)
                return BadRequest();

            var tipoUtilizador = _tipoUtilizadorRepository.GetTipoUtilizadores()
                .Where(u => u.Tipo.Trim().ToUpper() == tipoUtilizadorCriar.Tipo.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (tipoUtilizador != null)
            {
                ModelState.AddModelError("", "O tipo de utilizador já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var tipoUtilizadorMap = _mapper.Map<TipoUtilizador>(tipoUtilizadorCriar);

            if (!_tipoUtilizadorRepository.CriarTipoUtilizador(tipoUtilizadorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Tipo de Utilizador criado com sucesso!");
        }

        [HttpPut("{tipoUtilizadorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTipoUtilizador(int tipoUtilizadorId, [FromBody] TipoUtilizadorDto tipoUtilizadorAtualizado)
        {
            if (tipoUtilizadorAtualizado == null)
                return BadRequest(ModelState);

            if (tipoUtilizadorId != tipoUtilizadorAtualizado.TipoUtilizadorId)
                return BadRequest(ModelState);

            if (!_tipoUtilizadorRepository.TipoUtilizadorExists(tipoUtilizadorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var tipoUtilizadorMap = _mapper.Map<TipoUtilizador>(tipoUtilizadorAtualizado);

            if (!_tipoUtilizadorRepository.AtualizarTipoUtilizador(tipoUtilizadorMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
