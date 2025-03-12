using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models.DBModels;

public class Likes
{
    public DateTime Date { get; set; }
        
    [ForeignKey(nameof(User))]
    public int UserFk { get; set; }
    public Users User { get; set; }
        
    [ForeignKey(nameof(Media))]
    public int MediaFk { get; set; }
    public Media Media { get; set; }
}