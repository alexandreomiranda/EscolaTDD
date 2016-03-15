using DomainValidation.Validation;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Specifications.Alunos;

namespace EscolaTDD.Domain.Validations.Alunos
{
    public class AlunoCadastroValidation : Validator<Aluno>
    {
        public AlunoCadastroValidation(IAlunoRepository alunoRepository)
        {
            var cpfUnico = new AlunoCpfUnicoSpecification(alunoRepository);

            base.Add("cpfUnico", new Rule<Aluno>(cpfUnico, "CPF já cadastrado!"));
        }
    }
}
