using System.ComponentModel.DataAnnotations;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// Users da Aplicação
/// </summary>
public class Utilizadores 
{
    /// <summary>
    /// PK dos utilizadores para interligar com o ASPNETUSERS
    /// </summary>
    [Key]
    public string? IdentityUserName { get; set; }

    /// <summary>
    /// ID dos utilizadores 
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nome dos utilizadores 
    /// </summary>
    public string Nome { get; set; }
    
    /// <summary>
    /// Coleção dos likes do user
    /// </summary>
    public ICollection<Likes> ListaLikes { get; set; }
    
    
}

