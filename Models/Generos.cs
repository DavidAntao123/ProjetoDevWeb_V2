namespace ProjetoDevWeb_V2.Models;

/// <summary>
///  Generos dos Medias
/// </summary>
public class Generos
{
    /// <summary>
    /// Identificador do genero
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nome do genero
    /// </summary>
    public string Nome { get; set; }
    
    /// <summary>
    /// Descricao do genero
    /// </summary>
    public string Descricao { get; set; }
    
    public ICollection<Medias> ListaMedias { get; set; } = new List<Medias>();

}