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
    /// Controler da API das Musicas
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusicasController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get de todos as Musicas
        /// </summary>
        // GET: api/Musicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musicas>>> GetMusicas()
        {
            return await _context.Musicas.ToListAsync();
        }
        /// <summary>
        /// Get de uma musica em especifico por ID
        /// </summary>
        // GET: api/Musicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musicas>> GetMusicas(int id)
        {
            var Musicas = await _context.Musicas
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (Musicas == null)
            {
                return NotFound("O id fornecido não tem Música correspondente.");
            }

            return Musicas;
        }
        /// <summary>
        /// Atualiza uma musica em especifico
        /// </summary>
        // PUT: api/Musicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMusicas(int id, Musicas Musicas)
        {
            if (id != Musicas.Id)
            {
                return BadRequest();
            }

            _context.Entry(Musicas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicasExists(id))
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
        /// Adiciona uma musica 
        /// </summary>
        // POST: api/Musicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Fotografias>> PostMusicas(Musicas Musicas)
        {
            _context.Musicas.Add(Musicas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicas", new { id = Musicas.Id }, Musicas);
        }
        /// <summary>
        /// Apaga uma musica em especifico
        /// </summary>
        // DELETE: api/Musicas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMusicas(int id)
        {
            var Musicas = await _context.Musicas.FindAsync(id);
            if (Musicas == null)
            {
                return NotFound();
            }

            _context.Musicas.Remove(Musicas);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se uma musica existe
        /// </summary>
        private bool MusicasExists(int id)
        {
            return _context.Musicas.Any(e => e.Id == id);
        }
    }
}
