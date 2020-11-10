using Microsoft.AspNetCore.Mvc;
using NoticiasApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoticiasApi.Models;

namespace NoticiasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController:ControllerBase
    {
        private readonly AutorService _autorService;
        public AutorController(AutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = _autorService.Obtener();
            return Ok(resultado);
        }
    }
}
