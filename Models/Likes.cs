using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// 
/// </summary>

[PrimaryKey(nameof(UserFK),nameof(MediaFK))]
public class Likes
{
    public DateTime Data { get; set; }
    
    
    
    [ForeignKey(nameof(User))]
    
    public int UserFK { get; set; }
    
    public Users User { get; set; }
    
    
    
    
    [ForeignKey(nameof(Media))]
    
    public int MediaFK { get; set; }
    
    public Medias Media { get; set; }
}