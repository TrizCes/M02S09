using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Context;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly FilmesContext _context;

        public DiretoresController(FilmesContext context)
        {
            _context = context;
        }

        // GET: api/Diretores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diretor>>> GetDiretor()
        {
            return await _context.Diretor.ToListAsync();
        }

        // GET: api/Diretores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diretor>> GetDiretor(int id)
        {
            var diretor = await _context.Diretor.FindAsync(id);

            if (diretor == null)
            {
                return NotFound();
            }

            return diretor;
        }

        // PUT: api/Diretores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiretor(int id, Diretor diretor)
        {
            if (id != diretor.Id)
            {
                return BadRequest();
            }

            _context.Entry(diretor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiretorExists(id))
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

        // POST: api/Diretores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diretor>> PostDiretor(Diretor diretor)
        {
            _context.Diretor.Add(diretor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiretor", new { id = diretor.Id }, diretor);
        }

        // DELETE: api/Diretores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiretor(int id)
        {
            var diretor = await _context.Diretor.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }

            _context.Diretor.Remove(diretor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiretorExists(int id)
        {
            return _context.Diretor.Any(e => e.Id == id);
        }
    }
}
