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
    public class vehiculoesController : ControllerBase
    {
        private readonly EasycarContext _context;

        public vehiculoesController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/vehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vehiculo>>> Getvehiculo ()
        {
            return await _context.vehiculo.ToListAsync();
        }

        // GET: api/vehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<vehiculo>> Getvehiculo (int id)
        {
            var vehiculo = await _context.vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // PUT: api/vehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvehiculo (int id, vehiculo vehiculo)
        {
            if (id != vehiculo.id_vehiculo)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vehiculoExists(id))
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

        // POST: api/vehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<vehiculo>> Postvehiculo (vehiculo vehiculo)
        {
            _context.vehiculo.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvehiculo", new { id = vehiculo.id_vehiculo }, vehiculo);
        }

        // DELETE: api/vehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevehiculo (int id)
        {
            var vehiculo = await _context.vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool vehiculoExists (int id)
        {
            return _context.vehiculo.Any(e => e.id_vehiculo == id);
        }
    }
}
