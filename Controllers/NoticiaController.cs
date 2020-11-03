using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasApi.Models;
using NoticiasApi.Services;

namespace NoticiasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.Agregar(_noticia);
            if(resultado)
            {
                return Ok(_noticia);
            }
            else
            {
                return BadRequest();
            }           
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.Editar(_noticia);
            if (resultado)
            {
                return Ok(_noticia);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
