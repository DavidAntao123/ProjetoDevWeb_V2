using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevWeb_V2.Models.ApiModels;

public class MediasApi
{
    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public int Temporadas { get; set; }

    public int Episodios { get; set; }
}