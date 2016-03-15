using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;


namespace EscolaTDD.Domain.Specifications.Matriculas
{
    public class MatriculaUnicaSpecification : ISpecification<Matricula>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaUnicaSpecification(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public bool IsSatisfiedBy(Matricula matricula)
        {
            return _matriculaRepository.ObterMatriculaAlunoCurso(matricula.AlunoId, matricula.CursoId) == null;
        }
    }
}
