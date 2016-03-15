using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;

namespace EscolaTDD.Domain.Specifications.Alunos
{
    public class AlunoCpfUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoCpfUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorCpf(aluno.CPF) == null;
        }
    }
}
