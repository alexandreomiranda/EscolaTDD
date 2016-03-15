using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Validations.Alunos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EscolaTDD.Domain.Tests.Validation
{
    [TestClass]
    public class AlunoCadastroTest
    {
        public Aluno Aluno { get; set; }

        [TestMethod]
        public void Aluno_Validation_True()
        {
            Aluno = new Aluno()
            {
                CPF = "65560639834"
            };
            var stubRepository = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepository.Stub(s => s.ObterPorCpf(Aluno.CPF)).Return(null); // objeto não encontrado - null

            var alunoValidation = new AlunoCadastroValidation(stubRepository);
            Assert.IsTrue(alunoValidation.Validate(Aluno).IsValid);
        }
        [TestMethod]
        public void Aluno_Validation_False()
        {
            Aluno = new Aluno()
            {
                CPF = "65560639834"
            };
            var stubRepository = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepository.Stub(s => s.ObterPorCpf(Aluno.CPF)).Return(Aluno); // objeto encontrado

            var alunoValidation = new AlunoCadastroValidation(stubRepository);
            Assert.IsFalse(alunoValidation.Validate(Aluno).IsValid);
        }
    }
}
