using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Interfaces.Repository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Curso ObterPorCodigoCurso(string codigo);
    }
}
