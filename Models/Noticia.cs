namespace api_noticias.Models;

public class Noticia {
    public Guid NoticiaId {get; set;}
    public Guid CategoriaId {get; set;} 
    public string Titulo {get; set;}    

    public string Resumen {get; set;}

    public string Img  {get; set;}  
    public string Contenido {get; set;}
    public int Calificacion {get; set;}

    public string Nom_Autor {get; set;} 

    public DateTime FechaCreacion {get; set;}
    public virtual Categoria Categoria {get; set;}
}