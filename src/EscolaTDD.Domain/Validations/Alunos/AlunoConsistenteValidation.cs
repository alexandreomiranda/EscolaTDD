using DomainValidation.Validation;
using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Specifications.Alunos;

namespace EscolaTDD.Domain.Validations.Alunos
{
    public class AlunoConsistenteValidation : Validator<Aluno>
    {
        public AlunoConsistenteValidation()
        {
            var CPFAluno = new AlunoDeveTerCPFValidoSpecification();
            var alunoFaixaEtaria = new AlunoDeveTerIdadeEntre6a18Specification();

            base.Add("CPFAluno", new Rule<Aluno>(CPFAluno, "Aluno informou um CPF inválido."));
            base.Add("alunoFaixaEtaria", new Rule<Aluno>(alunoFaixaEtaria, "Aluno não se enquadra na faixa etária da escola."));
        }
    }
}
