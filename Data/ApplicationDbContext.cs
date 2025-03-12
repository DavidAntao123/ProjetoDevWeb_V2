using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoDevWeb_V2.Models.DBModels;

namespace ProjetoDevWeb_V2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Audios> Audios { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Autores> Autores { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Fotos> Fotos { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Likes> Likes { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Reviews> Reviews { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Users> Users { get; set; } 

public DbSet<ProjetoDevWeb_V2.Models.DBModels.Videos> Videos { get; set; } 

}