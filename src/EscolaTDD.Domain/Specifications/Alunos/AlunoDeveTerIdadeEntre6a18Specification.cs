using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Specifications.Alunos
{
    public class AlunoDeveTerIdadeEntre6a18Specification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return (DateTime.Now.Year - aluno.DataNascimento.Year >= 6 && DateTime.Now.Year - aluno.DataNascimento.Year <= 18);
        }
    }
}
