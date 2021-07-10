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
    public class preciosController : ControllerBase
    {
        private readonly EasycarContext _context;

        public preciosController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/precios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<precio>>> Getprecio ()
        {
            return await _context.precio.ToListAsync();
        }

        // GET: api/precios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<precio>> Getprecio (int id)
        {
            var precio = await _context.precio.FindAsync(id);

            if (precio == null)
            {
                return NotFound();
            }

            return precio;
        }

        // PUT: api/precios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprecio (int id, precio precio)
        {
            if (id != precio.id_precio)
            {
                return BadRequest();
            }

            _context.Entry(precio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!precioExists(id))
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

        // POST: api/precios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<precio>> Postprecio (precio precio)
        {
            _context.precio.Add(precio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprecio", new { id = precio.id_precio }, precio);
        }

        // DELETE: api/precios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprecio (int id)
        {
            var precio = await _context.precio.FindAsync(id);
            if (precio == null)
            {
                return NotFound();
            }

            _context.precio.Remove(precio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool precioExists (int id)
        {
            return _context.precio.Any(e => e.id_precio == id);
        }
    }
}
