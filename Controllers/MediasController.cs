using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;
using ProjetoDevWeb_V2.ViewModels;

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
            var applicationDbContext = _context.Medias.Include(m => m.Autor)
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .Include(m => m.Midade);
                
            
            
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> LikeMedia( int MediaFk, string UserFK , string likestatus)
        {
            try
            {
                
                bool userExists = await _context.Utilizadores.AnyAsync(u => u.IdentityUserName== UserFK );
                if (!userExists)
                {
                   return RedirectToAction(nameof(AllMedias),"Medias");

                }

                // 2. Check if the media exists
                bool mediaExists = await _context.Medias.AnyAsync(m => m.Id == MediaFk);
                if (!mediaExists)
                {
                    return RedirectToAction(nameof(AllMedias),"Medias");
                }
                Console.WriteLine("entrei fixe");
                Console.WriteLine(UserFK);
                Console.WriteLine(MediaFk);

                var existingLikes = await _context.Likes.FindAsync(User.Identity.Name, MediaFk);

                if (existingLikes == null)
                {
                    
                    var like = new Likes()
                    {
                        MediaFK = MediaFk,
                        UserFK = UserFK,
                        Data = DateTime.Now
                    };
                    _context.Likes.Add(like);

                    try
                    {
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException ex)
                    {
                        // Log the full error (including inner exceptions)
                        Console.WriteLine($"Save failed: {ex.InnerException?.Message}");
                        return Problem("Database update error");
                    }
                }
                else
                {
                    try
                    {
                        _context.Likes.Remove(existingLikes);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    
                }
                
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return RedirectToAction(nameof(AllMedias),"Medias");
        }

        public async Task<IActionResult> AllMedias()
        {
            var userId = User.Identity.Name;
            var medias = await _context.Medias
                .Include(m => m.Autor)
                .Include(m => m.Genero)
                .Include(m => m.TipoMedia)
                .Include(m => m.Midade)
                .ToListAsync();

            var fotografias = await _context.Fotografias.ToListAsync();

            var userLikes = await _context.Likes
                .Where(l => l.UserFK == userId)
                .Select(l => l.MediaFK)
                .ToListAsync();
            
            
            //instancia do objeto MediaFotografias 
            var viewModel = new MediaFotografias_Likes
            {
                // guarda todos os medias que existem com as FK
                Medias = medias,
                // guarda todos as fotos que existem
                Fotografias = fotografias, 
                
                LikesList = userLikes
            };

            return View("AllMedias", viewModel);
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
                .Include(m => m.Midade)
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
            ViewData["MidadeFk"] = new SelectList(_context.Midades, "Id", "Idade");
            
            return View();
        }

        // POST: Medias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,MidadeFk,GeneroFk,TipoMediaFk,Temporadas,Episodios,AutorFk")] Medias medias)
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
            ViewData["MidadeFk"] = new SelectList(_context.Midades, "Id", "Idade", medias.MidadeFk);
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
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Nome", medias.AutorFk);
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Nome", medias.GeneroFk);
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Nome", medias.TipoMediaFk);
            ViewData["MidadeFk"] = new SelectList(_context.Midades, "Id", "Idade", medias.MidadeFk);
            return View(medias);
        }

        // POST: Medias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,MidadeFk,GeneroFk,TipoMediaFk,Temporadas,Episodios,AutorFk")] Medias medias)
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
            ViewData["AutorFk"] = new SelectList(_context.Autores, "Id", "Nome", medias.AutorFk);
            ViewData["GeneroFk"] = new SelectList(_context.Generos, "Id", "Nome", medias.GeneroFk);
            ViewData["TipoMediaFk"] = new SelectList(_context.TipoMedias, "Id", "Nome", medias.TipoMediaFk);
            ViewData["MidadeFk"] = new SelectList(_context.Midades, "Id", "Idade", medias.MidadeFk);

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
                .Include(m => m.Midade)
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
