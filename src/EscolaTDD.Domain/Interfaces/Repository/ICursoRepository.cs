using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Interfaces.Repository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Curso ObterPorAnoLetivo(int ano);
        Curso ObterPorCodigoCurso(string codigo);
        string ObterCodigo(Guid id);
    }
}
