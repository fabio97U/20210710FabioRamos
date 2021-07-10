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
    public class modeloesController : ControllerBase
    {
        private readonly EasycarContext _context;

        public modeloesController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/modeloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<modelo>>> Getmodelo ()
        {
            return await _context.modelo.ToListAsync();
        }

        // GET: api/modeloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<modelo>> Getmodelo (int id)
        {
            var modelo = await _context.modelo.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/modeloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmodelo (int id, modelo modelo)
        {
            if (id != modelo.id_modelo)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!modeloExists(id))
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

        // POST: api/modeloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<modelo>> Postmodelo (modelo modelo)
        {
            _context.modelo.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmodelo", new { id = modelo.id_modelo }, modelo);
        }

        // DELETE: api/modeloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemodelo (int id)
        {
            var modelo = await _context.modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.modelo.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool modeloExists (int id)
        {
            return _context.modelo.Any(e => e.id_modelo == id);
        }
    }
}
