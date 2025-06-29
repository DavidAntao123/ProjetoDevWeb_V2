using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Data;
using ProjetoDevWeb_V2.Models;
using ProjetoDevWeb_V2.ViewModels;

namespace ProjetoDevWeb_V2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    
    /// <summary>
    ///  Metodo do index
    /// </summary>
    public IActionResult Index()
    {
        
        //instancia do objeto MediaFotografias 
        var viewModel = new MediaFotografias_Likes()
        {
            // guarda todos os medias que existem
            Medias = _context.Medias.Include(m => m.Fotos).ToList(),
            // guarda todos as fotos que existem
            Fotografias = _context.Fotografias.ToList()
        };
      //retorna o view model com os medias e as fotos
     return View(viewModel);
    }


    public IActionResult InserirMedia()
    {
        return View("Media/InserirMedia");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}