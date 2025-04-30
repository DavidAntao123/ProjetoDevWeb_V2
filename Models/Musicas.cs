using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

public class Musicas
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Link { get; set; }
    
    [ForeignKey(nameof(Media))]
    public int MediaFK { get; set; }
    public Medias Media { get; set; } 
}