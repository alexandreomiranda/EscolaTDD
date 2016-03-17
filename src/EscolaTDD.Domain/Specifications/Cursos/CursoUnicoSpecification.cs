using DomainValidation.Interfaces.Specification;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;

namespace EscolaTDD.Domain.Specifications.Cursos
{
    public class CursoUnicoSpecification : ISpecification<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        
        public CursoUnicoSpecification(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public bool IsSatisfiedBy(Curso curso)
        {
            return _cursoRepository.ObterPorCodigoCurso(curso.CodigoCurso) == null;
        }
    }
}
