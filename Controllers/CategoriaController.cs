using api_noticias.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_noticias.controllers;

[Route("api/categoria")]
public class CategoriaContoller:ControllerBase
{
    ICategoriaService categoriaservice;

    public CategoriaContoller(ICategoriaService service){
        categoriaservice=service;
    }

    [HttpGet]
    [Route("listado")]
    public IActionResult Get(){
        // return Ok("aas");
        return Ok(categoriaservice.Get());
    }
}