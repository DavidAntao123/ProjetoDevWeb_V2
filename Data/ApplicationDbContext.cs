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

public DbSet<Teste> Teste{ get; set; } 

public DbSet<Media> Media { get; set; }

}