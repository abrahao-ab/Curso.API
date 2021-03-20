using Curso.API.Business.Entities;
using Curso.API.Business.Repositories;
using Curso.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Curso.API.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;

        public CursoRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(curso Curso)
        {
            _contexto.Curso.Add(Curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<curso> ObterPorUsuario(int codigoUsuario)
        {
            return _contexto.Curso.Include(i => i.Usuario)
            .Where(w => w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
