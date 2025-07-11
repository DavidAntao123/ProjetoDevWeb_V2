using System.ComponentModel.DataAnnotations;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
///  autores dos Medias
/// </summary>

public class Autores
{
    /// <summary>
    /// Identificador do autor
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Identificador da categoria
    /// </summary>
    [Display(Name = "Nome do Autor")]
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")] 
    public string Nome { get; set; }

    public ICollection<Medias> ListaMedias { get; set; } = new List<Medias>();

}