using api_noticias.Models;
using api_noticias.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_noticias.controllers;

// [Route("api/[controller]")]
[Route("api/noticia")]
public class NoticiaController:ControllerBase 
{
    INoticiaService noticiaservice;

    public NoticiaController(INoticiaService service){
        noticiaservice = service;
    }

    [HttpGet]
    [Route("listnoticia")]
    public IActionResult listNoticias(){
        return Ok(noticiaservice.Get());
    }

    [HttpPost]
    [Route("registrar")]
    public IActionResult Registrar([FromBody] Noticia noticia){
        noticiaservice.Save(noticia);
        return Ok("El registro fue exitoso");
    }
    [HttpPut]
    [Route("actCalificacion")]
    public IActionResult ActualizarCalificacion(Guid id,[FromBody] Noticia noticia){
        noticiaservice.Update(id,noticia);
        return Ok("La noticia se Califico con exito");
    }

    [HttpDelete]
    [Route("eliminar")]

    public IActionResult EliminarNotia(Guid id){
        noticiaservice.Delete(id);
        return Ok("La Noticia se ha eliminado de forma exitosa");
    }
}