using Curso.API.Controllers;

namespace Curso.API.Config
{
    public interface IAuthenticationService
    {
        object GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
