using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models.DBModels;

/// <summary>
/// Media existente no site 
/// </summary>
public class Media
{
    //ID da Media
    public int Id { get; set; }
    
    //Titulo da Media
    [Required(ErrorMessage = "O {0} é obrigatório !")]
    [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
    public string Titulo { get; set; }
    
    //Quantidade de Episodios
    public int Quantidade { get; set; }
    
    //Descricao / resumo da Media
    public string Descricao { get; set; }
    
    
    // Enum com os tipos de Media existentes
    public TipoMedia Tipo { get; set; }
    
    
    /*
     * FK com a o nome do autor  (  Autores.Nome    )
     */
    [ForeignKey(nameof(Nome))]
    public int AutorFk { get; set; }
    public Autores Nome { get; set; }
    
}


/// <summary>
/// Enum com os tipos de Media existens,
/// Para adicionar algum , basta por a ", " , enter e escrever
/// </summary>
public enum TipoMedia
{
    Animes,
    Filmes,
    Livros,
    Podcasts,
    Series
}