using FilmesAPI.Context;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [Route("api/v{version:apiVersion}/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        private readonly FilmesContext _filmesContext;

        public FilmesController(FilmesContext filmesContext)
        {
            _filmesContext = filmesContext;
        }

        // GET: api/<FilmesController>
        /// <summary>
        /// Lista mocada de filmes
        /// </summary>
        /// <returns>Retorna uma lista mocada de filmes</returns>
        /// <response code = "200">Sucesso no retorno da lista mocada de filmes</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filmes = await _filmesContext.Filmes.ToListAsync().ConfigureAwait(true);
            return Ok(filmes);
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
        public async Task<IActionResult> Get(int id)
        {
            Filme filme = await _filmesContext.Filmes
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(true);

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
        public async Task<IActionResult> Post([FromBody] Filme filme)
        {
            _filmesContext.Filmes.Add(filme);

            await _filmesContext.SaveChangesAsync();

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
        public async Task<IActionResult> Put(int id, [FromBody] Filme filme)
        {
            bool existeFilme = await _filmesContext.Filmes
                                                   .AnyAsync(x => x.Id == id)
                                                   .ConfigureAwait(true);

            if (!existeFilme) { return NotFound(); }

            _filmesContext.Entry(filme).State = EntityState.Modified;

            await _filmesContext.SaveChangesAsync();

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
        public async Task<IActionResult> Delete(int id)
        {
            var filme = await _filmesContext.Filmes
                                            .FirstOrDefaultAsync(x => x.Id == id)
                                            .ConfigureAwait(true);
            
            if (filme is null) { return NotFound(); }

            _filmesContext.Filmes.Remove(filme);
            await _filmesContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
