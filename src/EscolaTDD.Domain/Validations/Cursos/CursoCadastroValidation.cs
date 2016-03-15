using DomainValidation.Validation;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Specifications.Cursos;

namespace EscolaTDD.Domain.Validations.Cursos
{
    public class CursoCadastroValidation : Validator<Curso>
    {
        public CursoCadastroValidation(ICursoRepository cursoRepository)
        {
            var cursoUnico = new CursoUnicoSpecification(cursoRepository);

            base.Add("cursoUnicoRule", new Rule<Curso>(cursoUnico, "Código de curso já está cadastrado!"));
        }
    }
}
