using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCamping.Filter;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;
using SmartCampingAPI.Repository;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUtilizadorRepository _utilizadorRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, IUtilizadorRepository utilizadorRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _utilizadorRepository = utilizadorRepository;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))] // Not actually needed
        public IActionResult GetClientes()
        {
            var clientes = _mapper.Map<List<ClienteDto>>
                (_clienteRepository.GetClientes());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cliente))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetCliente(int id)
        {
            if (!_clienteRepository.ClienteExists(id))
                return NotFound();

            var cliente = _mapper.Map<ClienteDto>
                (_clienteRepository.GetCliente(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(cliente);
        }

        [HttpGet("utilizador/{id}")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        public IActionResult GetClienteUtilizador(int id)
        {
            if(!_utilizadorRepository.UtilizadorExists(id))
                return NotFound();

            var cliente = _mapper.Map<ClienteDto>(_clienteRepository.GetClienteUtilizador(id));

            if(!ModelState.IsValid) 
                return BadRequest();

            return Ok(cliente);
        }

        [HttpGet("{id}/reservas")]
        [ProducesResponseType(200, Type = typeof(Reserva))] // Not actually needed
        [ProducesResponseType(400)]
        public IActionResult GetReservasPorCliente(int id)
        {
            var reservasCliente = _mapper.Map<List<ReservaDto>>
                (_clienteRepository.GetReservasPorCliente(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservasCliente);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CriarCliente([FromBody] ClienteDto clienteCriar)
        {
            if (clienteCriar == null)
                return BadRequest();

            var cliente = _clienteRepository.GetClientes()
                .Where(c => c.NIF == clienteCriar.NIF)
                .FirstOrDefault();

            if (cliente != null)
            {
                ModelState.AddModelError("", "O cliente já existe!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var clienteMap = _mapper.Map<Cliente>(clienteCriar);

            if (!_clienteRepository.CriarCliente(clienteMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Cliente criado com sucesso!");
        }

        [HttpPut("{clienteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCliente(int clienteId, [FromBody] ClienteDto clienteAtualizado)
        {
            if (clienteAtualizado == null)
                return BadRequest(ModelState);

            if (clienteId != clienteAtualizado.ClienteId)
                return BadRequest(ModelState);

            if (!_clienteRepository.ClienteExists(clienteId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var clienteMap = _mapper.Map<Cliente>(clienteAtualizado);

            if (!_clienteRepository.AtualizarCliente(clienteMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
