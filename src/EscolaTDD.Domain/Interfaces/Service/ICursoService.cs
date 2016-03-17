using EscolaTDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Interfaces.Service
{
    public interface ICursoService : IDisposable
    {
        Curso Adicionar(Curso curso);
        Curso ObterPorId(Guid id);
        IEnumerable<Curso> ObterTodos();
        Curso Atualizar(Curso curso);
        void Remover(Guid id);

        Curso ObterPorAnoLetivo(int ano);
        Curso ObterPorCodigoCurso(string codigo);
        string ObterCodigo(Guid id);
    }
}
