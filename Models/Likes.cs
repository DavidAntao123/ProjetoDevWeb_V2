using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// Likes dos Medias
/// </summary>

[PrimaryKey(nameof(UserFK),nameof(MediaFK))]
public class Likes
{
    
    // Data que o utilizador da like
    public DateTime Data { get; set; }
    
    
    /// <summary>
    /// Fk para referenciar o utilizador que gosta da fotografia
    /// </summary>
    [ForeignKey(nameof(Utilizadore))]
    public int UserFK { get; set; }
    public Utilizadores Utilizadore { get; set; }
    
    /// <summary>
    /// Fk para referenciar o media
    /// </summary>
    [ForeignKey(nameof(Media))]
    public int MediaFK { get; set; }
    public Medias Media { get; set; }
}