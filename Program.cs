using api_noticias;
using api_noticias.Services;
// using api_noticias.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<NoticiasContext>(builder.Configuration.GetConnectionString("cnnTarea"));

builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<INoticiaService,NoticiaService>();

builder.Services.AddCors(option=>{
    option.AddPolicy("cors",app=>{
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

