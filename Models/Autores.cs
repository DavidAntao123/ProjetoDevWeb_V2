namespace ProjetoDevWeb_V2.Models;

public class Autores
{
    
    public int Id { get; set; }
    
    public string Nome { get; set; }

    public List<Medias> Medias { get; set; } = [];
}