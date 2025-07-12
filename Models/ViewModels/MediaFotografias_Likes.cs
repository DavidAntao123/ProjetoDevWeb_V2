using ProjetoDevWeb_V2.Models;

namespace ProjetoDevWeb_V2.ViewModels;

public class MediaFotografias_Likes
{
    public List<Medias> Medias { get; set; }
    public List<Fotografias> Fotografias { get; set; }
    
    public List<Generos> Generos { get; set; }
    
    public List<int> LikesList { get; set; }
    
    public Dictionary<int, int> LikeCounts { get; set; }

    
}