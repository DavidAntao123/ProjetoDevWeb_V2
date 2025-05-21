using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

public class Medias
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }
    
    public string Descricao { get; set; }
    
    // M/6  M/12 ETC.
    public string Idade { get; set; }
    
    
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
    
}

