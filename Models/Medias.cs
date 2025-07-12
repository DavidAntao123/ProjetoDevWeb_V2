using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// Medias da aplicacao
/// </summary>
public class Medias
{
    /// <summary>
    /// Identificador do Media
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Titulo do Media
    /// </summary>
    public string Titulo { get; set; }
    
    /// <summary>
    /// Descricao do Media
    /// </summary>
    public string Descricao { get; set; }
    
    /// <summary>
    /// Minima idade que é recomendado para ver o Media
    /// </summary>
    [ForeignKey(nameof(Midade))]
    public int MidadeFk { get; set; }
    public Midades Midade { get; set; }

    
    
    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Género")]
    [ForeignKey(nameof(Genero))]
    public int GeneroFk { get; set; }
    public Generos Genero { get; set; }
    
    /// <summary>
    ///
    /// 
    /// </summary>
    [Display(Name = "TipoMedia")]
    [ForeignKey(nameof(TipoMedia))]
    public int TipoMediaFk { get; set; }
    
    public TipoMedias TipoMedia { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Temporadas { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    
    public int Episodios { get; set; }
    
    [ForeignKey(nameof(Autor))]
    public int AutorFk { get; set; }
    
    public Autores Autor { get; set; }
    
    public List<Fotografias> Fotos { get; set; }
    
    public List<Musicas> Musicas { get; set; }
    
}

