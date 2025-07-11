namespace ProjetoDevWeb_V2.Models;

public class Midades
{
    /// <summary>
    /// Identificador da idade minima
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Idade minima (A ou M/13)
    /// </summary>
    public string Idade { get; set; }
    
    /// <summary>
    /// Descrição da idade minima
    /// </summary>
    public string Descricao { get; set; }
    
    /// <summary>
    /// Lista de Medias
    /// </summary>

    public ICollection<Medias> ListaMedias { get; set; } = new List<Medias>();
}