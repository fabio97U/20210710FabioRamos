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
    public class serviciosController : ControllerBase
    {
        private readonly EasycarContext _context;

        public serviciosController (EasycarContext context)
        {
            _context = context;
        }

        // GET: api/servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<servicio>>> Getservicio ()
        {
            return await _context.servicio.ToListAsync();
        }

        // GET: api/servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<servicio>> Getservicio (int id)
        {
            var servicio = await _context.servicio.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/servicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putservicio (int id, servicio servicio)
        {
            if (id != servicio.id_servicio)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicioExists(id))
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

        // POST: api/servicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<servicio>> Postservicio (servicio servicio)
        {
            _context.servicio.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getservicio", new { id = servicio.id_servicio }, servicio);
        }

        // DELETE: api/servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteservicio (int id)
        {
            var servicio = await _context.servicio.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.servicio.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool servicioExists (int id)
        {
            return _context.servicio.Any(e => e.id_servicio == id);
        }
    }
}
