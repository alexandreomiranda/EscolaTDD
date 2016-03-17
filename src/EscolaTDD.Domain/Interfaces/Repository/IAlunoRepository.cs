using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        int ObterIdade(Guid aluno);
        Aluno ObterPorCpf(string cpf);
    }
}
