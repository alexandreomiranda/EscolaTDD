using EscolaTDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Interfaces.Service
{
    public interface IMatriculaService : IDisposable
    {
        Matricula Adicionar(Matricula matricula);
        Matricula ObterPorId(Guid id);
        IEnumerable<Matricula> ObterTodos();
        Matricula Atualizar(Matricula matricula);
        void Remover(Guid id);

        Matricula ObterMatriculaAlunoCurso(Guid aluno, Guid curso);
        bool ValidarFaixaEtariaPorCurso(Guid aluno, Guid curso);
    }
}
