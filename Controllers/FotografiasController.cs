using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;

namespace ProjetoDevWeb_V2.Controllers
{
    /// <summary>
    /// Controller responsável pelas Fotografias
    /// </summary>
    public class FotografiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotografiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fotografias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fotografias.Include(f => f.Media);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fotografias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .Include(f => f.Media)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // GET: Fotografias/Create
        public IActionResult Create()
        {
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Titulo");
            return View();
        }

        // POST: Fotografias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,MediaFK,Ficheiro,Publico")] Fotografias fotografia , List<IFormFile> fileFoto)
        {
            bool haImagem = false;
            var nomeImg = "";
            
            var media = _context.Medias.Where(c => c.Id == fotografia.MediaFK);
            
            //Verifica se o media selecionado existe
            
            if (!media.Any())
            {
                ModelState.AddModelError("MediaFk","Selecione um Media correto");
            }

            //Verifica se a foto foi submetida
    
            
            if (fileFoto == null)
            {
                ModelState.AddModelError("","Submeta um ficheiro");
            }
            
            if (ModelState.IsValid)
            {
                //Verifica se a foto é .png ou .jpeg
                //se nao um dos dois , ira ser substituido por uma imagem predefinida
                if (!(fileFoto[0].ContentType == "image/png" || fileFoto[0].ContentType == "image/jpeg"))
                {
                    fotografia.Ficheiro = "sad.png";
                }
                else
                {
                    //boolean a indicar que existe uma imagem
                    haImagem = true;
                    
                    //cria um nome valor aleatorio unico
                    Guid g = Guid.NewGuid();
                    
                    //converte para o valor aleatorio para o nome da imagem
                    nomeImg = g.ToString();
                    
                    // guarda a extensao e em minusculas
                    string extensao = Path.GetExtension(fileFoto[0].FileName).ToLowerInvariant();
                    
                    //combina o guid com a extensao
                    nomeImg += extensao;
                    
                    //Define o caminho da imagem
                    fotografia.Ficheiro = "imagens/"+nomeImg;
                }

                //se existe uma imagem
                if (haImagem)
                {
                    
                    // define o path para o wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/imagens");
                    
                    //se nao existir a pasta , ira criar
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    
                    //adiciona o nome da imagem ao caminho
                    filePath = Path.Combine(filePath, nomeImg);

                    //salva o ficheiro
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileFoto[0].CopyToAsync(fileStream);
                    }
                }
                _context.Add(fotografia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Titulo", fotografia.MediaFK);
            return View(fotografia);
        }

        // GET: Fotografias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias.FindAsync(id);
            if (fotografias == null)
            {
                return NotFound();
            }
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Titulo", fotografias.MediaFK);
            return View(fotografias);
        }

        // POST: Fotografias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,MediaFK,Ficheiro,Publico")] Fotografias fotografias , List<IFormFile> fileFoto)
        {
            if (id != fotografias.Id)
            {
                return NotFound();
            }
    
            if (ModelState.IsValid)
            {
               
                
                try
                {
                    _context.Update(fotografias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografiasExists(fotografias.Id))
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
            ViewData["MediaFK"] = new SelectList(_context.Medias, "Id", "Id", fotografias.MediaFK);
            return View(fotografias);
        }

        // GET: Fotografias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .Include(f => f.Media)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // POST: Fotografias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotografias = await _context.Fotografias.FindAsync(id);
            if (fotografias != null)
            {
                _context.Fotografias.Remove(fotografias);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografiasExists(int id)
        {
            return _context.Fotografias.Any(e => e.Id == id);
        }
    }
}
