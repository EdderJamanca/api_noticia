using api_noticias.Models;
using Microsoft.EntityFrameworkCore;

namespace api_noticias;

public class NoticiasContext:DbContext 
{
    public DbSet<Categoria> Categoria {get;set;}
    public DbSet<Noticia> Noticia {get;set;}

    public NoticiasContext(DbContextOptions<NoticiasContext> options): base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder){

    List<Categoria> categoriaInit = new List<Categoria>();
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),Nom_Categoria="Política"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb401"),Nom_Categoria="Deportivas"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"),Nom_Categoria="Culturales"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb403"),Nom_Categoria="Sociales"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"),Nom_Categoria="De Farandula"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb405"),Nom_Categoria="Cientificas"});
    categoriaInit.Add(new Categoria(){CategoriaId=Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb406"),Nom_Categoria="Económicas"});

        modelBuilder.Entity<Categoria>(categoria=>{
             categoria.ToTable("Categoria");

             categoria.HasKey(p=>p.CategoriaId);
             categoria.Property(p=>p.Nom_Categoria).IsRequired().HasMaxLength(500);

             categoria.HasData(categoriaInit);
        });

        modelBuilder.Entity<Noticia>(noticia =>{
            noticia.ToTable("Noticia");

            noticia.HasKey(p=>p.NoticiaId);
            noticia.HasOne(p=>p.Categoria).WithMany(p=>p.Noticia).HasForeignKey(p=>p.CategoriaId);
            noticia.Property(p=>p.Titulo).IsRequired().HasMaxLength(150);
            noticia.Property(p=>p.Resumen).IsRequired().HasMaxLength(1500);
            noticia.Property(p=>p.Img).IsRequired(false).HasMaxLength(150);
            noticia.Property(p=>p.Contenido).IsRequired().HasMaxLength(8000);
            noticia.Property(p=>p.Calificacion).HasDefaultValueSql("0");
            noticia.Property(p=>p.FechaCreacion).HasDefaultValueSql("SYSDATETIME()");
            noticia.Property(p=>p.Nom_Autor).IsRequired(false);

        });
    }
}