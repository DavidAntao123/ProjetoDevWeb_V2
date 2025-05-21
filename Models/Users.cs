namespace ProjetoDevWeb_V2.Models;

/// <summary>
/// Users da Aplicação
/// </summary>
public class Users
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public Tipos Tipo { get; set; }
    
    
}

public enum Tipos
{
    Admin,
    User
}