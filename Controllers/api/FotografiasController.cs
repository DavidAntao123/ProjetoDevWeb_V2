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
    [Route("api/[controller]")]
    [ApiController]
    public class FotografiasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FotografiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fotografias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotografias>>> GetFotografias()
        {
            return await _context.Fotografias.ToListAsync();
        }

        // GET: api/Fotografias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fotografias>> GetFotografias(int id)
        {
            var fotos = await _context.Fotografias
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (fotos == null)
            {
                return NotFound("O id fornecido não tem Foto correspondente.");
            }

            return fotos;
        }

        // PUT: api/Fotografias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFotografias(int id, Fotografias fotos)
        {
            if (id != fotos.Id)
            {
                return BadRequest();
            }

            _context.Entry(fotos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotografiasExists(id))
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

        // POST: api/Fotografias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        // [Route("create")]
        public async Task<ActionResult<Fotografias>> PostFotografias(Fotografias fotos)
        {
            _context.Fotografias.Add(fotos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFotografias", new { id = fotos.Id }, fotos);
        }

        // DELETE: api/Fotografias/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFotografias(int id)
        {
            var fotos = await _context.Fotografias.FindAsync(id);
            if (fotos == null)
            {
                return NotFound();
            }

            _context.Fotografias.Remove(fotos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FotografiasExists(int id)
        {
            return _context.Fotografias.Any(e => e.Id == id);
        }
    }
}
