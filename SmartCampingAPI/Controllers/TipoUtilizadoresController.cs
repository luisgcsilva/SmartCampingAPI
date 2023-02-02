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
    }
}
