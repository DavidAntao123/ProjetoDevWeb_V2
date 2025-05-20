using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;

namespace ProjetoDevWeb_V2.Controllers
{
    public class MediasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MediasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medias.
                Include(m => m.Autor)
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Medias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medias = await _context.Medias
                .Include(m => m.Autor)
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medias == null)
            {
                return NotFound();
            }

            return View(medias);
        }

        // GET: Medias/Create
        public IActionResult Create()
        {
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Nome");
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Nome");
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Nome");
            return View();
        }

        // POST: Medias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Idade,GeneroFk,TipoMediaFk,Temporadas,Episodios,AutorFk")] Medias medias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Nome", medias.AutorFk);
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Nome", medias.GeneroFk);
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Nome", medias.TipoMediaFk);
            return View(medias);
        }

        // GET: Medias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medias = await _context.Medias.FindAsync(id);
            if (medias == null)
            {
                return NotFound();
            }
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Id", medias.AutorFk);
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Id", medias.GeneroFk);
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Id", medias.TipoMediaFk);
            return View(medias);
        }

        // POST: Medias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Idade,GeneroFk,TipoMediaFk,Temporadas,Episodios,AutorFk")] Medias medias)
        {
            if (id != medias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediasExists(medias.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Id", medias.AutorFk);
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Id", medias.GeneroFk);
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Id", medias.TipoMediaFk);
            return View(medias);
        }

        // GET: Medias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medias = await _context.Medias
                .Include(m => m.Autor)
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medias == null)
            {
                return NotFound();
            }

            return View(medias);
        }

        // POST: Medias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medias = await _context.Medias.FindAsync(id);
            if (medias != null)
            {
                _context.Medias.Remove(medias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediasExists(int id)
        {
            return _context.Medias.Any(e => e.Id == id);
        }
    }
}
