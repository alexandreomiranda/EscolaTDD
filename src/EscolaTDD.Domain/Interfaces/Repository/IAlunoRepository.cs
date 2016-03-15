using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno ObterPorCpf(string cpf);
    }
}
