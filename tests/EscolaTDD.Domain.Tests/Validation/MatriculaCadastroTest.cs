using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscolaTDD.Domain.Entities;
using System;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Validations.Matriculas;
using Rhino.Mocks;

namespace EscolaTDD.Domain.Tests.Validation
{
    [TestClass]
    public class MatriculaCadastroTest
    {
        public Matricula Matricula { get; set; }

        [TestMethod]
        public void Matricula_Validation_True()
        {
            Matricula = new Matricula()
            {
                AlunoId = new Guid("b2c7e6da-4086-4bf3-9c2f-225852da34c3"),
                CursoId = new Guid("b7b6c5a1-2cea-4ee2-9967-b34d4f76ece6")
            };
            var stubRepository = MockRepository.GenerateStub<IMatriculaRepository>();
            stubRepository.Stub(s => s.ObterMatriculaAlunoCurso(Matricula.AlunoId, Matricula.CursoId)).Return(null);
            stubRepository.Stub(s => s.ValidarFaixaEtariaPorCurso(Matricula.AlunoId, Matricula.CursoId)).Return(true);

            var matriculaValidation = new MatriculaCadastroValidation(stubRepository);
            Assert.IsTrue(matriculaValidation.Validate(Matricula).IsValid);
        }

        [TestMethod]
        public void Matricula_Validation_False()
        {
            Matricula = new Matricula()
            {
                AlunoId = new Guid("b2c7e6da-4086-4bf3-9c2f-225852da34c3"),
                CursoId = new Guid("b7b6c5a1-2cea-4ee2-9967-b34d4f76ece6")
            };
            var stubRepository = MockRepository.GenerateStub<IMatriculaRepository>();
            stubRepository.Stub(s => s.ObterMatriculaAlunoCurso(Matricula.AlunoId, Matricula.CursoId)).Return(Matricula);
            stubRepository.Stub(s => s.ValidarFaixaEtariaPorCurso(Matricula.AlunoId, Matricula.CursoId)).Return(false);

            var matriculaValidation = new MatriculaCadastroValidation(stubRepository);
            var result = matriculaValidation.Validate(Matricula);

            Assert.IsFalse(matriculaValidation.Validate(Matricula).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Aluno já possui matrícula para esse curso!"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Aluno fora da faixa etária para esse curso!"));
        }
    }
}
