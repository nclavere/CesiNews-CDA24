using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;

namespace CesiNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportsController : ControllerBase
    {
        private readonly NewsDbContext _context;

        public SupportsController(NewsDbContext context)
        {
            _context = context;
        }

        // GET: api/Supports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Support>>> GetSupports()
        {
            return await _context.Supports.ToListAsync();
        }

        // GET: api/Supports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Support>> GetSupport(int id)
        {
            var support = await _context.Supports.FindAsync(id);

            if (support == null)
            {
                return NotFound();
            }

            return support;
        }

        // PUT: api/Supports/Texte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Texte/{id}")]
        public async Task<IActionResult> PutSupport(int id, Texte support)
        {
            if (id != support.Id)
            {
                return BadRequest();
            }

            _context.Entry(support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(id))
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

        // PUT: api/Supports/Video/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Video/{id}")]
        public async Task<IActionResult> PutSupport(int id, Video support)
        {
            if (id != support.Id)
            {
                return BadRequest();
            }

            _context.Entry(support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(id))
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

        // POST: api/Supports/Texte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("texte")]
        public async Task<ActionResult<Support>> PostSupport(Texte support)
        {
            _context.Supports.Add(support);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupport", new { id = support.Id }, support);
        }

        // POST: api/Supports/Video
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("video")]
        public async Task<ActionResult<Support>> PostSupport(Video support)
        {
            _context.Supports.Add(support);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupport", new { id = support.Id }, support);
        }

        // DELETE: api/Supports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupport(int id)
        {
            var support = await _context.Supports.FindAsync(id);
            if (support == null)
            {
                return NotFound();
            }

            _context.Supports.Remove(support);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportExists(int id)
        {
            return _context.Supports.Any(e => e.Id == id);
        }
    }
}
