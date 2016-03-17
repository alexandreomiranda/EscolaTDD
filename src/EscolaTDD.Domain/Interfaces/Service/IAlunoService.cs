using EscolaTDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Interfaces.Service
{
    public interface IAlunoService : IDisposable
    {
        Aluno Adicionar(Aluno aluno);
        Aluno ObterPorId(Guid id);
        IEnumerable<Aluno> ObterTodos();
        Aluno Atualizar(Aluno aluno);
        void Remover(Guid id);

        int ObterIdade(Guid id);
        Aluno ObterPorCpf(string cpf);
    }
}
