using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaAutos.Server.Context;
using VentaAutos.Shared.Modelos;

namespace VentaAutos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tipo_negocioController : ControllerBase
    {
        private readonly EasycarContext _context;

        public tipo_negocioController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/tipo_negocio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tipo_negocio>>> Gettipo_negocio ()
        {
            return await _context.tipo_negocio.ToListAsync();
        }

        // GET: api/tipo_negocio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tipo_negocio>> Gettipo_negocio (int id)
        {
            var tipo_negocio = await _context.tipo_negocio.FindAsync(id);

            if (tipo_negocio == null)
            {
                return NotFound();
            }

            return tipo_negocio;
        }

        // PUT: api/tipo_negocio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttipo_negocio (int id, tipo_negocio tipo_negocio)
        {
            if (id != tipo_negocio.id_tipo_negocio)
            {
                return BadRequest();
            }

            _context.Entry(tipo_negocio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipo_negocioExists(id))
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

        // POST: api/tipo_negocio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tipo_negocio>> Posttipo_negocio (tipo_negocio tipo_negocio)
        {
            _context.tipo_negocio.Add(tipo_negocio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettipo_negocio", new { id = tipo_negocio.id_tipo_negocio }, tipo_negocio);
        }

        // DELETE: api/tipo_negocio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetipo_negocio (int id)
        {
            var tipo_negocio = await _context.tipo_negocio.FindAsync(id);
            if (tipo_negocio == null)
            {
                return NotFound();
            }

            _context.tipo_negocio.Remove(tipo_negocio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tipo_negocioExists (int id)
        {
            return _context.tipo_negocio.Any(e => e.id_tipo_negocio == id);
        }
    }
}
