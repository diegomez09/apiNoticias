using Microsoft.EntityFrameworkCore;
using NoticiasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasApi.Services
{
    public class AutorService
    {
        private readonly DBContext _autorDbContext;
        public AutorService(DBContext autorDbContext)
        {
            _autorDbContext = autorDbContext;
        }
        public List<Autor> Obtener()
        {
            try
            {
                var autores = _autorDbContext.Autor.ToList();
                return autores;
            }
            catch(Exception error)
            {
                return new List<Autor>();
            }            
        }
    }
}
