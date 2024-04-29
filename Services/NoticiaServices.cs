using api_noticias.Models;

namespace api_noticias.Services;

public class NoticiaService:INoticiaService
{
     NoticiasContext context;

     public NoticiaService(NoticiasContext dbcontext){
        context=dbcontext;
     }

     public IEnumerable<Noticia> Get()
     {
        return context.Noticia;
     }

     public async Task Save(Noticia noticia){
        context.Add(noticia);
        await context.SaveChangesAsync();
     }

    public async Task Update(Guid id,Noticia noticia){

        var noticiaActual=context.Noticia.Find(id);

        if(noticiaActual!=null){
            noticiaActual.Calificacion=noticia.Calificacion;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var noticiaActual=context.Noticia.Find(id);
        if(noticiaActual!=null){
            context.Remove(noticiaActual);
            await context.SaveChangesAsync();   
        }
    }
}


public interface INoticiaService {
    IEnumerable<Noticia> Get();

    Task Save(Noticia noticia);

    Task Update(Guid id,Noticia noticia);
    Task Delete(Guid id);   

}