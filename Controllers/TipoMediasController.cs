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
    
    [Authorize]
    public class TipoMediasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoMediasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoMedias
        public async Task<IActionResult> Index()
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            return View(await _context.TipoMedias.ToListAsync());
        }

        // GET: TipoMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedias = await _context.TipoMedias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedias == null)
            {
                return NotFound();
            }

            return View(tipoMedias);
        }

        // GET: TipoMedias/Create
        public IActionResult Create()
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            return View();
        }

        // POST: TipoMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] TipoMedias tipoMedias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMedias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMedias);
        }

        // GET: TipoMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedias = await _context.TipoMedias.FindAsync(id);
            if (tipoMedias == null)
            {
                return NotFound();
            }
            return View(tipoMedias);
        }

        // POST: TipoMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] TipoMedias tipoMedias)
        {
            if (id != tipoMedias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMedias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMediasExists(tipoMedias.Id))
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
            return View(tipoMedias);
        }

        // GET: TipoMedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedias = await _context.TipoMedias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedias == null)
            {
                return NotFound();
            }

            return View(tipoMedias);
        }

        // POST: TipoMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMedias = await _context.TipoMedias.FindAsync(id);
            if (tipoMedias != null)
            {
                _context.TipoMedias.Remove(tipoMedias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMediasExists(int id)
        {
            return _context.TipoMedias.Any(e => e.Id == id);
        }
    }
}
