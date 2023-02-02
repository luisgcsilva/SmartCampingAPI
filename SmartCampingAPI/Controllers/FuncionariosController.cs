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
    }
}
