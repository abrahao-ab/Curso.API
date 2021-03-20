using Curso.API.Business.Entities;
using System.Collections.Generic;

namespace Curso.API.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(curso Curso);

        void Commit();

        IList<curso> ObterPorUsuario(int codigoUsuario);
    }
}
