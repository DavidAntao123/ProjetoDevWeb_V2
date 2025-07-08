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
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MediasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Medias
        [HttpGet]
        public ActionResult GetMedias()
        {
            if (User.Identity.IsAuthenticated)
            {
                var resultAut = _context.Medias.ToList();
                return Ok(resultAut);
            }
                
            var result = _context.Medias
                .Select(f => new MediasApi{Titulo = f.Titulo, Descricao = f.Descricao})
                .ToList();
                
            return Ok(result);
        }

        // GET: api/Medias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medias>> GetMedias(int id)
        {
            var medias = await _context.Medias.FindAsync(id);

            if (medias == null)
            {
                return NotFound();
            }

            return medias;
        }
    }
}

