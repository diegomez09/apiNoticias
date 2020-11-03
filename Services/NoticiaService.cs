using Microsoft.EntityFrameworkCore;
using NoticiasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasApi.Services
{
    public class NoticiaService
    {
        private readonly DBContext _noticiaDbContext;
        public NoticiaService(DBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        public Boolean Agregar(Noticia _noticia)
        {
            try
            {
                _noticiaDbContext.Noticia.Add(_noticia);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }            
        }

        public List<Noticia> Obtener()
        {
            var resultado = _noticiaDbContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        public Boolean Editar(Noticia _noticia)
        {
            try
            {
                var noticiaBaseDatos = _noticiaDbContext.Noticia.Where(noticia => 
                noticia.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBaseDatos.Titulo = _noticia.Titulo;
                noticiaBaseDatos.Contenido = _noticia.Contenido;
                noticiaBaseDatos.Fecha = _noticia.Fecha;
                noticiaBaseDatos.AutorID = _noticia.AutorID;
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Eliminar(int NoticiaID)
        {
            try
            {
                var noticiaBaseDatos = _noticiaDbContext.Noticia.Where(noticia =>
                noticia.NoticiaID == NoticiaID).FirstOrDefault();
                _noticiaDbContext.Noticia.Remove(noticiaBaseDatos);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }
    }
}
