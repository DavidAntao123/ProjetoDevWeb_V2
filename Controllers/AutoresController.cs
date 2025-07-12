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
    /// <summary>
    /// Controller responsável pelos Autores
    /// </summary>
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Autores
        public async Task<IActionResult> AllAutores()
        {
            
            return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var autores = await _context.Autores
                .Include(a => a.ListaMedias)  
                .FirstOrDefaultAsync(a => a.Id == id);
            if (autores == null)
            {
                return NotFound();
            }

            return View(autores);
        }

        // GET: Autores/Create
        [Authorize]
        public IActionResult Create()
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Autores"); 
            }
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autores);
        }

        // GET: Autores/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Autores"); 
            }
            if (id == null)
            {
                return NotFound();
            }

            var autores = await _context.Autores.FindAsync(id);
            if (autores == null)
            {
                return NotFound();
            }
            return View(autores);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Autores autores)
        {
            if (id != autores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresExists(autores.Id))
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
            return View(autores);
        }

        // GET: Autores/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Autores"); 
            }
            if (id == null)
            {
                return NotFound();
            }

            var autores = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autores == null)
            {
                return NotFound();
            }
            
            var mediaNomes = await _context.Medias
                .Where(m => m.AutorFk == id)
                .Select(m => m.Titulo) 
                .ToListAsync();

            if (mediaNomes.Any())
            {
                ViewBag.Aviso = "Aviso : Este Autor está a ser utilizado nestes Medias :";
                ViewBag.MediaNomes = mediaNomes; 
            }
            
            return View(autores);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autores = await _context.Autores.FindAsync(id);
            if (autores != null)
            {
                _context.Autores.Remove(autores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoresExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
