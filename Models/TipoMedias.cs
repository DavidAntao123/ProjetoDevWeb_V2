namespace ProjetoDevWeb_V2.Models;

public class TipoMedias
{
    /// <summary>
    /// Identificador do tipo de media
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// nome do tipo de media
    /// </summary>
    public string Nome { get; set; }
    
    /// <summary>
    /// descrição do tipo de media
    /// </summary>
    public string Descricao { get; set; }
    
    public ICollection<Medias> ListaMedias { get; set; } = new List<Medias>();

    
    
}