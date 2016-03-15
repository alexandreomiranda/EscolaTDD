using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Validations.Documents;

namespace EscolaTDD.Domain.Specifications.Alunos
{
    public class AlunoDeveTerCPFValidoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return CPFValidation.Validar(aluno.CPF);
        }
    }
}
