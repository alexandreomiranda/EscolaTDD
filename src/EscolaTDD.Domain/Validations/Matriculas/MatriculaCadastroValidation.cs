using DomainValidation.Validation;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Specifications.Matriculas;

namespace EscolaTDD.Domain.Validations.Matriculas
{
	public class MatriculaCadastroValidation : Validator<Matricula>
	{
		public MatriculaCadastroValidation(IMatriculaRepository matriculaRepository)
		{
			var matriculaUnica = new MatriculaUnicaSpecification(matriculaRepository);
			var matriculaFaixaEtaria = new MatriculaFaixaEtariaPorCursoSpecification(matriculaRepository);

			base.Add("matriculaUnicaRule", new Rule<Matricula>(matriculaUnica, "Aluno já possui matrícula para esse curso!"));
			base.Add("matriculaFaixaEtariaRule", new Rule<Matricula>(matriculaFaixaEtaria, "Aluno fora da faixa etária para esse curso!"));
		}
		
	}
}
