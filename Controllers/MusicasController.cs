using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;

namespace ProjetoDevWeb_V2.Controllers
{
    
    public class MusicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Musicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Musicas.Include(m => m.Media);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas
                .Include(m => m.Media)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicas == null)
            {
                return NotFound();
            }

            return View(musicas);
        }

        // GET: Musicas/Create
        
        //[Authorize]
        public IActionResult Create()
        {
            /*
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            */
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Titulo");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Link,MediaFK")] Musicas musicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Id", musicas.MediaFK);
            return View(musicas);
        }

        // GET: Musicas/Edit/5
        //[Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            /*
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            */
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas.FindAsync(id);
            if (musicas == null)
            {
                return NotFound();
            }
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Titulo", musicas.MediaFK);
            return View(musicas);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Link,MediaFK")] Musicas musicas)
        {
            if (id != musicas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicasExists(musicas.Id))
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
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Id", musicas.MediaFK);
            return View(musicas);
        }

        // GET: Musicas/Delete/5
        //[Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            /*
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            */
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas
                .Include(m => m.Media)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicas == null)
            {
                return NotFound();
            }

            return View(musicas);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicas = await _context.Musicas.FindAsync(id);
            if (musicas != null)
            {
                _context.Musicas.Remove(musicas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicasExists(int id)
        {
            return _context.Musicas.Any(e => e.Id == id);
        }
    }
}
