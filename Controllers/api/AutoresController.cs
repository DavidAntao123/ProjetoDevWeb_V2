using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoDevWeb_V2.Controllers.api
{
    /// <summary>
    /// Controler da API dos Autores
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get de todos os Autores
        /// </summary>
        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autores>>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        /// <summary>
        /// Get de um autor em especifico por ID
        /// </summary>
        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autores>> GetAutores(int id)
        {
            var autores = await _context.Autores
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (autores == null)
            {
                return NotFound("O id fornecido não tem Autor correspondente.");
            }

            return autores;
        }

        /// <summary>
        /// Atualiza um autor em especifico
        /// </summary>
        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFotografias(int id, Autores autores)
        {
            if (id != autores.Id)
            {
                return BadRequest();
            }

            _context.Entry(autores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoresExists(id))
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
        /// Adiciona um autor 
        /// </summary>
        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Autores>> PostAutores(Autores autores)
        {
            _context.Autores.Add(autores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutores", new { id = autores.Id }, autores);
        }

        /// <summary>
        /// Apaga um autor em especifico
        /// </summary>
        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAutores(int id)
        {
            var autores = await _context.Autores.FindAsync(id);
            if (autores == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autores);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se um autor existe
        /// </summary>
        private bool AutoresExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
