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
    [Route("api/[controller]")]
    [ApiController]
    public class AlojamentosController : ControllerBase
    {
        private readonly SmarCampingDBContext _context;

        public AlojamentosController(SmarCampingDBContext context)
        {
            _context = context;
        }

        // GET: api/Alojamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alojamento>>> GetAlojamentos()
        {
            return await _context.Alojamentos.ToListAsync();
        }

        // GET: api/Alojamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alojamento>> GetAlojamento(int id)
        {
            var alojamento = await _context.Alojamentos.FindAsync(id);

            if (alojamento == null)
            {
                return NotFound();
            }

            return alojamento;
        }

        // PUT: api/Alojamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlojamento(int id, Alojamento alojamento)
        {
            if (id != alojamento.AlojamentoId)
            {
                return BadRequest();
            }

            _context.Entry(alojamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlojamentoExists(id))
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

        // POST: api/Alojamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alojamento>> PostAlojamento(Alojamento alojamento)
        {
            _context.Alojamentos.Add(alojamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlojamento", new { id = alojamento.AlojamentoId }, alojamento);
        }

        // DELETE: api/Alojamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlojamento(int id)
        {
            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento == null)
            {
                return NotFound();
            }

            _context.Alojamentos.Remove(alojamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlojamentoExists(int id)
        {
            return _context.Alojamentos.Any(e => e.AlojamentoId == id);
        }
    }
}
