using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCamping.Data;
using SmartCamping.Models;

namespace SmartCamping.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class TipoAlojamentosController : ControllerBase
    {
        private readonly SmarCampingDBContext _context;

        public TipoAlojamentosController(SmarCampingDBContext context)
        {
            _context = context;
        }

        // GET: api/TipoAlojamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAlojamento>>> GetTipoAlojamentos()
        {
            return await _context.TipoAlojamentos.ToListAsync();
        }

        // GET: api/TipoAlojamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAlojamento>> GetTipoAlojamento(int id)
        {
            var tipoAlojamento = await _context.TipoAlojamentos.FindAsync(id);

            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            return tipoAlojamento;
        }

        // PUT: api/TipoAlojamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAlojamento(int id, TipoAlojamento tipoAlojamento)
        {
            if (id != tipoAlojamento.TipoAlojamentoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoAlojamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAlojamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoAlojamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAlojamento>> PostTipoAlojamento(TipoAlojamento tipoAlojamento)
        {
            _context.TipoAlojamentos.Add(tipoAlojamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoAlojamento", new { id = tipoAlojamento.TipoAlojamentoId }, tipoAlojamento);
        }

        // DELETE: api/TipoAlojamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAlojamento(int id)
        {
            var tipoAlojamento = await _context.TipoAlojamentos.FindAsync(id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            _context.TipoAlojamentos.Remove(tipoAlojamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAlojamentoExists(int id)
        {
            return _context.TipoAlojamentos.Any(e => e.TipoAlojamentoId == id);
        }
    }
}
