using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Context;
using FilmesAPI.Models;
using FilmesAPI.DTO;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeDiretorController : ControllerBase
    {
        private readonly FilmesContext _context;

        public FilmeDiretorController(FilmesContext context)
        {
            _context = context;
        }

        // GET: api/FilmeDiretor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDiretor>>> GetFilmeDiretor()
        {
            return await _context.FilmeDiretor
                .Include(x => x.Filme)
                .Include(x => x.Diretor)
                .ToListAsync();
        }

        // GET: api/FilmeDiretor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeDiretor>> GetFilmeDiretor(int id)
        {
            var filmeDiretor = await _context.FilmeDiretor.FindAsync(id);

            if (filmeDiretor == null)
            {
                return NotFound();
            }

            return filmeDiretor;
        }

        // PUT: api/FilmeDiretor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmeDiretor(int id, FilmeDiretorDTO filmeDiretorDto)
        {
            if (id != filmeDiretorDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmeDiretorDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeDiretorExists(id))
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

        // POST: api/FilmeDiretor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmeDiretor>> PostFilmeDiretor(FilmeDiretorDTO filmeDiretorDto)
        {
            var configuration = new MapperConfiguration(
                cfg => cfg.CreateMap<FilmeDiretorDTO, FilmeDiretor>());

            var mapper = configuration.CreateMapper();

            FilmeDiretor filmeDiretor = mapper.Map<FilmeDiretor>(filmeDiretorDto);

            _context.FilmeDiretor.Add(filmeDiretor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmeDiretor", new { id = filmeDiretor.Id }, filmeDiretor);
        }

        // DELETE: api/FilmeDiretor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmeDiretor(int id)
        {
            var filmeDiretor = await _context.FilmeDiretor.FindAsync(id);
            if (filmeDiretor == null)
            {
                return NotFound();
            }

            _context.FilmeDiretor.Remove(filmeDiretor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeDiretorExists(int id)
        {
            return _context.FilmeDiretor.Any(e => e.Id == id);
        }
    }
}
