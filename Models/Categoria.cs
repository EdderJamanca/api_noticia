using System.Text.Json.Serialization;

namespace api_noticias.Models;

public class Categoria 
{
    public Guid CategoriaId { get; set; }
    public string Nom_Categoria { get; set; }

    [JsonIgnore]
    public virtual ICollection<Noticia> Noticia {get;set;}
}