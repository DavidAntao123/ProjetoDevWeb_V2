using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;
using ProjetoDevWeb_V2.Models.ApiModels;

namespace ProjetoDevWeb_V2.Controllers.api
{
    /// <summary>
    /// Controler da API dos Medias
    /// GET PUT POST DELETE
    /// Para utilizar , é necessário de estar autenticados na API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MediasController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get de todos os Medias
        /// </summary>
        // GET: api/Medias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediasAutDto>>> GetMedias()
        {
            return await _context.Medias
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .Include(m => m.Autor)
                .Include(m => m.Fotos)
                .Include(m => m.Musicas)
                .Select(m => new MediasAutDto()
                {
                    Id = m.Id,
                    Titulo = m.Titulo,
                    Descricao = m.Descricao,
                    MidadeFk = m.MidadeFk,
                    GeneroFk = m.GeneroFk,
                    TipoMediaFk = m.TipoMediaFk,
                    Temporadas = m.Temporadas,
                    Episodios = m.Episodios,
                    AutorFk = m.AutorFk,
                    FotoIds = m.Fotos.Select(f => f.Id).ToList(),
                    MusicaIds = m.Musicas.Select(m => m.Id).ToList()
                })
                .ToListAsync();
        }
        /// <summary>
        /// Get de um media em especifico por ID
        /// </summary>
        // GET: api/Medias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediasAutDto>> GetMedia(int id)
        {
            var media = await _context.Medias
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .Include(m => m.Autor)
                .Include(m => m.Fotos)
                .Include(m => m.Musicas)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (media == null)
            {
                return NotFound();
            }

            return new MediasAutDto()
            {
                Id = media.Id,
                Titulo = media.Titulo,
                Descricao = media.Descricao,
                MidadeFk = media.MidadeFk,
                GeneroFk = media.GeneroFk,
                TipoMediaFk = media.TipoMediaFk,
                Temporadas = media.Temporadas,
                Episodios = media.Episodios,
                AutorFk = media.AutorFk,
                FotoIds = media.Fotos.Select(f => f.Id).ToList(),
                MusicaIds = media.Musicas.Select(m => m.Id).ToList()

            };
        }
        
        /// <summary>
        /// Atualiza um media em especifico
        /// </summary>
        // PUT: api/Medias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(int id, MediasAutDto MediasAutDto)
        {
            if (id != MediasAutDto.Id)
            {
                return BadRequest();
            }

            var media = await _context.Medias
                .Include(m => m.Fotos)
                .Include(m => m.Musicas)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (media == null)
            {
                return NotFound();
            }

            media.Titulo = MediasAutDto.Titulo;
            media.Descricao = MediasAutDto.Descricao;
            media.MidadeFk = MediasAutDto.MidadeFk;
            media.GeneroFk = MediasAutDto.GeneroFk;
            media.TipoMediaFk = MediasAutDto.TipoMediaFk;
            media.Temporadas = MediasAutDto.Temporadas;
            media.Episodios = MediasAutDto.Episodios;
            media.AutorFk = MediasAutDto.AutorFk;

            media.Fotos = await _context.Fotografias
                .Where(f => MediasAutDto.FotoIds.Contains(f.Id))
                .ToListAsync();

            media.Musicas = await _context.Musicas
                .Where(m => MediasAutDto.MusicaIds.Contains(m.Id))
                .ToListAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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
        /// Adiciona um media 
        /// </summary>
        // POST: api/Medias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medias>> PostMedia(Medias medias)
        {
            _context.Medias.Add(medias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedias", new { id = medias.Id }, medias);
        }
        
        /// <summary>
        /// Apaga um media em especifico
        /// </summary>
        // DELETE: api/Medias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            var media = await _context.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Função para verificar se um media existe
        /// </summary>
        private bool MediaExists(int id)
        {
            return _context.Medias.Any(e => e.Id == id);
        }
    }
}
