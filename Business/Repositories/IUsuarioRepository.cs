using Curso.API.Business.Entities;

namespace Curso.API.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
