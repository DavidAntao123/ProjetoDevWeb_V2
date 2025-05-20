using ProjetoDevWeb_V2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Models;


namespace ProjetoDevWeb_V2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Autores> Autores { get; set; }
    
    public DbSet<Generos> Generos { get; set; }


    public DbSet<Likes> Likes { get; set; }
    public DbSet<Medias> Medias { get; set; }
    public DbSet<Musicas> Musicas { get; set; }
    
    public DbSet<TipoMedias> TipoMedias { get; set; }
    
    public DbSet<Users> Users { get; set; }

public DbSet<ProjetoDevWeb_V2.Models.Fotografias> Fotografias { get; set; }


}