using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanity.API.Data;
using Vanity.API.Models;

namespace Vanity.API.PaymentGateway
{
    [Route("api/Planvpn")]
    [ApiController]
    public class PlanesVpnsController : ControllerBase
    {
        private readonly VanityContext _context;

        public PlanesVpnsController(VanityContext context)
        {
            _context = context;
        }

        // GET: api/PlanesVpns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanesVpn>>> GetPlanesVpns()
        {
            return await _context.PlanesVpns.ToListAsync();
        }

        // GET: api/PlanesVpns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanesVpn>> GetPlanesVpn(int id)
        {
            var planesVpn = await _context.PlanesVpns.FindAsync(id);

            if (planesVpn == null)
            {
                return NotFound();
            }

            return planesVpn;
        }

        // PUT: api/PlanesVpns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanesVpn(int id, PlanesVpn planesVpn)
        {
            if (id != planesVpn.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(planesVpn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanesVpnExists(id))
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

        // POST: api/PlanesVpns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CrearPlan")]
        public async Task<ActionResult<PlanesVpn>> PostPlanesVpn(PlanesVpn planesVpn)
        {
            _context.PlanesVpns.Add(planesVpn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanesVpn", new { id = planesVpn.PlanId }, planesVpn);
        }

        // DELETE: api/PlanesVpns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanesVpn(int id)
        {
            var planesVpn = await _context.PlanesVpns.FindAsync(id);
            if (planesVpn == null)
            {
                return NotFound();
            }

            _context.PlanesVpns.Remove(planesVpn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanesVpnExists(int id)
        {
            return _context.PlanesVpns.Any(e => e.PlanId == id);
        }
    }
}
