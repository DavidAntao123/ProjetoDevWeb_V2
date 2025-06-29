using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

public class Musicas
{
    /// <summary>
    /// Identificador da musica
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Titulo da musica
    /// </summary>
    public string Titulo { get; set; }
    /// <summary>
    /// Link da musica (youtube music)
    /// </summary>
    public string Link { get; set; }
    
    /// <summary>
    /// Fk para o media associado a musica
    /// </summary>
    
    [ForeignKey(nameof(Media))]
    public int MediaFK { get; set; }
    public Medias Media { get; set; } 
}