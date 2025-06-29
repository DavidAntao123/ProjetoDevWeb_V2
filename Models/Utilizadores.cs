using System.ComponentModel.DataAnnotations;

namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// Users da Aplicação
/// </summary>
public class Utilizadores 
{
    [Key]
    public string? IdentityUserName { get; set; }

    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    
    public ICollection<Likes> ListaLikes { get; set; }
    
    
}

