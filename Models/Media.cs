namespace ProjetoDevWeb_V2.Models;

public class Media
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public TipoMedia TipoMedia { get; set; }
    
    
}

public enum TipoMedia
{
    Anime,
    Filme,
    Podcast,
    Serie
    
}