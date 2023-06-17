using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class AlojamentoFotosController : ControllerBase
    {
        private readonly IAlojamentoFotosRepository _alojamentoFotosRepository;
        private readonly IMapper _mapper;

        public AlojamentoFotosController(IAlojamentoFotosRepository IAlojamentoFotosRepository, IMapper mapper)
        {
            _alojamentoFotosRepository = IAlojamentoFotosRepository;
            _mapper = mapper;
        }

        [HttpGet("{alojamentoid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AlojamentoFotos>))]
        public IActionResult GetAlojamentoFotos(int alojamentoid)
        {
            var alojamentoFotos = _mapper.Map<List<AlojamentoFotosDto>>
                (_alojamentoFotosRepository.GetAlojamentoFotos(alojamentoid));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(alojamentoFotos);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarAlojamentoFotos([FromBody] AlojamentoFotosDto alojamentoFotos)
        {
            if(alojamentoFotos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var alojamentoFotosMap = _mapper.Map<AlojamentoFotos>(alojamentoFotos);

            if (!_alojamentoFotosRepository.CriarAlojamentoFotos(alojamentoFotosMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Foto Adicionadas com sucesso!");
        }
    }
}
