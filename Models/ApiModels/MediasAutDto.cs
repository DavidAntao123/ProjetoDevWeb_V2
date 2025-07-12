using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models.ApiModels;

public class MediasAutDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int MidadeFk { get; set; }
    public int GeneroFk { get; set; }
    public int TipoMediaFk { get; set; }
    public int Temporadas { get; set; }
    public int Episodios { get; set; }
    public int AutorFk { get; set; }
    public List<int> FotoIds { get; set; }
    public List<int> MusicaIds { get; set; }

}