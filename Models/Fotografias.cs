using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
///  Fotografias dos medias
/// </summary>
public class Fotografias
{
    /// <summary>
    /// Identificador da fotografia
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Descricao da fotografia
    /// </summary>
    public string Descricao { get; set; }
    
    /// <summary>
    /// FK para referenciar o media da foto
    /// </summary>
    
    [Display(Name = "Nome do Media")]
    [ForeignKey(nameof(Media))]
    public int MediaFK { get; set; }
    public Medias Media { get; set; } 
    
    /// <summary>
    /// string com o caminho do ficheiro
    /// </summary>
    public string Ficheiro { get; set; }
    
    /// <summary>
    /// int para identificar se a foto é publicavel
    /// </summary>
    
    public int Publico { get; set; }

}