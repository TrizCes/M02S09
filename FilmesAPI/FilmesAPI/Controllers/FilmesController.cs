using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesAPI.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        // GET: api/<FilmesController>
        [HttpGet]
        public IEnumerable<Filme> Get()
        {
            return MockFilmes.Filmes;
        }

        // GET api/<FilmesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Filme filme = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);
            if(filme is null)
            {
                return NotFound();
            }
            return Ok(filme); 
        }

        // POST api/<FilmesController>
        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            MockFilmes.Filmes.Add(filme);

            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        // PUT api/<FilmesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Filme filme)
        {
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if(filmeUpdate is null) { return NotFound();  }

            var index = MockFilmes.Filmes.IndexOf(filmeUpdate);

            if(index != -1)
            {
                MockFilmes.Filmes[index] = filme;
            }
            return NoContent();
        }

        // DELETE api/<FilmesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
