using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;

namespace EscolaTDD.Domain.Specifications.Matriculas
{
    public class MatriculaFaixaEtariaPorCursoSpecification : ISpecification<Matricula>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaFaixaEtariaPorCursoSpecification(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public bool IsSatisfiedBy(Matricula matricula)
        {
            return _matriculaRepository.ValidarFaixaEtariaPorCurso(matricula.AlunoId, matricula.CursoId);
        }
    }
}
