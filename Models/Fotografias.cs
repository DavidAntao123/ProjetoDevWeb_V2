using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models;

public class Fotografias
{
    public int Id { get; set; }
    
    public string Descricao { get; set; }
    
    [Display(Name = "Nome do Media")]
    [ForeignKey(nameof(Media))]
    
    public int MediaId { get; set; }
    
    public Medias Media { get; set; }
    
    public string Ficheiro { get; set; }

}