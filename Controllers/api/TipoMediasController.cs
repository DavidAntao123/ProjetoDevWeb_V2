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
    /// Controler da API dos Tipos de Medias
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMediasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoMediasController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get de todos os Tipos de medias
        /// </summary>
        // GET: api/TipoMedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMedias>>> GetTipoMedias()
        {
            return await _context.TipoMedias.ToListAsync();
        }
        /// <summary>
        /// Get de um tipo de media em especifico por ID
        /// </summary>
        // GET: api/TipoMedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMedias>> GetTipoMedias(int id)
        {
            var TipoMedias = await _context.TipoMedias
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (TipoMedias == null)
            {
                return NotFound("O id fornecido não tem Tipo de Media correspondente.");
            }

            return TipoMedias;
        }
        /// <summary>
        /// Atualiza um Tipo de media em especifico
        /// </summary>
        // PUT: api/TipoMedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTipoMedias(int id, TipoMedias TipoMedias)
        {
            if (id != TipoMedias.Id)
            {
                return BadRequest();
            }

            _context.Entry(TipoMedias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMediasExists(id))
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
        /// Adiciona um tipo de media 
        /// </summary>
        // POST: api/TipoMedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Fotografias>> PostTipoMedias(TipoMedias TipoMedias)
        {
            _context.TipoMedias.Add(TipoMedias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMedias", new { id = TipoMedias.Id }, TipoMedias);
        }
        /// <summary>
        /// Apaga um tipo de media em especifico
        /// </summary>
        // DELETE: api/TipoMedias/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTipoMedias(int id)
        {
            var TipoMedias = await _context.TipoMedias.FindAsync(id);
            if (TipoMedias == null)
            {
                return NotFound();
            }

            _context.TipoMedias.Remove(TipoMedias);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se um autor existe
        /// </summary>
        private bool TipoMediasExists(int id)
        {
            return _context.TipoMedias.Any(e => e.Id == id);
        }
    }
}
