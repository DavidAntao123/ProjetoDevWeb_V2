namespace ProjetoDevWeb_V2.Models;

public class Midades
{
    public int Id { get; set; }
    public string Idade { get; set; }
    public string Descricao { get; set; }

    public List<Medias> ListaMedias { get; set; } = [];
}