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
    public class MidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Midades
        public async Task<IActionResult> Index()
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            return View(await _context.Midades.ToListAsync());
        }

        // GET: Midades/Details/5
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

            var midades = await _context.Midades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midades == null)
            {
                return NotFound();
            }

            return View(midades);
        }

        // GET: Midades/Create
        public IActionResult Create()
        {
            var Userrole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Userrole != "admin")
            {
                return RedirectToAction("Index","Home"); 
            }
            return View();
        }

        // POST: Midades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idade,Descricao")] Midades midades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(midades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(midades);
        }

        // GET: Midades/Edit/5
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

            var midades = await _context.Midades.FindAsync(id);
            if (midades == null)
            {
                return NotFound();
            }
            return View(midades);
        }

        // POST: Midades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idade,Descricao")] Midades midades)
        {
            if (id != midades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(midades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MidadesExists(midades.Id))
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
            return View(midades);
        }

        // GET: Midades/Delete/5
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

            var midades = await _context.Midades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midades == null)
            {
                return NotFound();
            }

            return View(midades);
        }

        // POST: Midades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var midades = await _context.Midades.FindAsync(id);
            if (midades != null)
            {
                _context.Midades.Remove(midades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MidadesExists(int id)
        {
            return _context.Midades.Any(e => e.Id == id);
        }
    }
}
