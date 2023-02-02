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
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Funcionario>))] // Not actually needed
        public IActionResult GetFuncionarios()
        {
            var funcionarios = _mapper.Map<List<FuncionarioDto>>
                (_funcionarioRepository.GetFuncionarios());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Funcionario))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetFuncionario(int id)
        {
            if (!_funcionarioRepository.FuncionarioExtists(id))
                return NotFound();

            var funcionario = _mapper.Map<FuncionarioDto>
                (_funcionarioRepository.GetFuncionario(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(funcionario);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarFuncionario([FromBody] FuncionarioDto funcionarioCriar)
        {
            if (funcionarioCriar == null)
                return BadRequest();

            var funcionario = _funcionarioRepository.GetFuncionarios()
                .Where(f => f.Telemovel == funcionarioCriar.Telemovel)
                .FirstOrDefault();

            if (funcionario != null)
            {
                ModelState.AddModelError("", "O funcionário já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var funcionarioMap = _mapper.Map<Funcionario>(funcionarioCriar);

            if (!_funcionarioRepository.CriarFuncionario(funcionarioMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Funcionario criado com sucesso!");
        }

        [HttpPut("{funcionarioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFuncionario(int funcionarioId, [FromBody] FuncionarioDto funcionarioAtualizado)
        {
            if (funcionarioAtualizado == null)
                return BadRequest(ModelState);

            if (funcionarioId != funcionarioAtualizado.FuncionarioId)
                return BadRequest(ModelState);

            if (!_funcionarioRepository.FuncionarioExtists(funcionarioId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var funcionarioMap = _mapper.Map<Funcionario>(funcionarioAtualizado);

            if (!_funcionarioRepository.AtualizarFuncionario(funcionarioMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
