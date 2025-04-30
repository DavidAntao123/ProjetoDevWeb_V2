using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

public class Medias
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }
    
    public string Descricao { get; set; }
    
    // M/6  M/12 ETC.
    public string Idade { get; set; }
    
    public Genero Genero { get; set; }
    
    public TipoMedia TipoMedia { get; set; }
    
    public int Temporadas { get; set; }
    
    public int Episodios { get; set; }
    
    public DateTime Data { get; set; }
    
    
    [ForeignKey(nameof(Autor))]
    public int AutorFk { get; set; }
    
    public Autores Autor { get; set; }
    
}

public enum TipoMedia
{
    Anime,
    Filme,
    Podcast,
    Serie
    
}

public enum Genero
{
    Acao,
    Aventura,
    Comedia,
    Terror,
    Romance,
    Documentario
    
}