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
    /// Controler da API das Midades
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MidadesController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get de todos as Midades
        /// </summary>
        // GET: api/Midades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Midades>>> GetMidades()
        {
            return await _context.Midades.ToListAsync();
        }
        /// <summary>
        /// Get de uma Midade em especifico por ID
        /// </summary>
        // GET: api/Midades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Midades>> GetMidades(int id)
        {
            var Midades = await _context.Midades
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (Midades == null)
            {
                return NotFound("O id fornecido não tem Midade correspondente.");
            }

            return Midades;
        }
        /// <summary>
        /// Atualiza uma Midade em especifico
        /// </summary>
        // PUT: api/Midades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMidades(int id, Midades Midades)
        {
            if (id != Midades.Id)
            {
                return BadRequest();
            }

            _context.Entry(Midades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MidadesExists(id))
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
        /// Adiciona uma Midade 
        /// </summary>
        // POST: api/Midades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Fotografias>> PostMidades(Midades Midades)
        {
            _context.Midades.Add(Midades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMidades", new { id = Midades.Id }, Midades);
        }
        /// <summary>
        /// Apaga uma Midade em especifico
        /// </summary>
        // DELETE: api/Midades/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMidades(int id)
        {
            var Midades = await _context.Midades.FindAsync(id);
            if (Midades == null)
            {
                return NotFound();
            }

            _context.Midades.Remove(Midades);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se uma Midade existe
        /// </summary>
        private bool MidadesExists(int id)
        {
            return _context.Midades.Any(e => e.Id == id);
        }
    }
}
