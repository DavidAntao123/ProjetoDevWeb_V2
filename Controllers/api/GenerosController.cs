using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoDevWeb_V2.Controllers.api
{
    /// <summary>
    /// Controler da API dos Generos
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get de todos os generos
        /// </summary>
        // GET: api/Generos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Generos>>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }
        /// <summary>
        /// Get de um genero em especifico por ID
        /// </summary>
        // GET: api/Generos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Generos>> GetGeneros(int id)
        {
            var generos = await _context.Generos
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (generos == null)
            {
                return NotFound("O id fornecido não tem Genero correspondente.");
            }

            return generos;
        }
        /// <summary>
        /// Atualiza um genero em especifico
        /// </summary>
        // PUT: api/Generos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutGeneros(int id, Generos generos)
        {
            if (id != generos.Id)
            {
                return BadRequest();
            }

            _context.Entry(generos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenerosExists(id))
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
        /// <summary>
        /// Adiciona um genero 
        /// </summary>
        // POST: api/Generos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Fotografias>> PostGeneros(Generos generos)
        {
            _context.Generos.Add(generos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneros", new { id = generos.Id }, generos);
        }
        /// <summary>
        /// Apaga um genero em especifico
        /// </summary>
        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGeneros(int id)
        {
            var generos = await _context.Generos.FindAsync(id);
            if (generos == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(generos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se um genero existe
        /// </summary>
        private bool GenerosExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }
    }
}
