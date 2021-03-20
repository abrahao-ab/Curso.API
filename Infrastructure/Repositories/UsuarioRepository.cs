using Curso.API.Business.Entities;
using Curso.API.Business.Repositories;
using Curso.API.Infrastructure.Data;
using System.Linq;

namespace Curso.API.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;

        public UsuarioRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }
        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario()
        {
            throw new System.NotImplementedException();
        }

        public Usuario ObterUsuario(string login)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
