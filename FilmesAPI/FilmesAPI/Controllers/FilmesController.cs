using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesAPI.Controllers
{
    [Route("api/v{version:apiVersion}/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        // GET: api/<FilmesController>
        /// <summary>
        /// Lista mocada de filmes
        /// </summary>
        /// <returns>Retorna uma lista mocada de filmes</returns>
        /// <response code = "200">Sucesso no retorno da lista mocada de filmes</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Filme> Get()
        {
            return MockFilmes.Filmes;
        }

        // GET api/<FilmesController>/5
        /// <summary>
        /// Requisição do Item de uma lista de filmes mocada
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Retorno do objeto filme</returns>
        /// <response code="404">Id não encontrado</response>
        /// <response code="200">Sucesso no retorno do objeto filme</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Criação de um filme
        /// </summary>
        /// <param name="filme">Objeto Filme</param>
        /// <returns>Criação do Filme</returns>
        /// <response code="201">Objeto Filme criado com sucesso</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            MockFilmes.Filmes.Add(filme);

            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        // PUT api/<FilmesController>/5
        /// <summary>
        /// Atualização do Filme
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <param name="filme">Objeto do Filme</param>
        /// <returns>Atualização do Filme</returns>
        /// <response code="404">Filme não encontrado</response>
        /// <response code="201">Atualização do Filme realizada com sucesso</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Remoção do Filme
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Remoção do Filme</returns>
        /// <response code="404">Filme não encontrado</response>
        /// <response code="204">Filme removido com sucesso</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Filme filmeDelete = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if (filmeDelete is null) { return NotFound(); }

            MockFilmes.Filmes.Remove(filmeDelete);

            return NoContent();
        }
    }
}
