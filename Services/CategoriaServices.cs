using api_noticias.Models;

namespace api_noticias.Services;

public class CategoriaService:ICategoriaService
{
    NoticiasContext context;

    public CategoriaService(NoticiasContext dbcontext){
        context = dbcontext;
    }

    public IEnumerable<Categoria> Get(){
        return context.Categoria;
    }


}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
}