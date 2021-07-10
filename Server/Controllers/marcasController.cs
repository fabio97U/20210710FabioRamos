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
    public class marcasController : ControllerBase
    {
        private readonly EasycarContext _context;

        public marcasController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<marca>>> Getmarca ()
        {
            return await _context.marca.ToListAsync();
        }

        // GET: api/marcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<marca>> Getmarca (int id)
        {
            var marca = await _context.marca.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // PUT: api/marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmarca (int id, marca marca)
        {
            if (id != marca.id_marca)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!marcaExists(id))
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

        // POST: api/marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<marca>> Postmarca (marca marca)
        {
            _context.marca.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmarca", new { id = marca.id_marca }, marca);
        }

        // DELETE: api/marcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemarca (int id)
        {
            var marca = await _context.marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.marca.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool marcaExists (int id)
        {
            return _context.marca.Any(e => e.id_marca == id);
        }
    }
}
