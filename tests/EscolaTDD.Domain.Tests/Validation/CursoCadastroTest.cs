using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Validations.Cursos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EscolaTDD.Domain.Tests.Validation
{
    [TestClass]
    public class CursoCadastroTest
    {
        public Curso Curso { get; set; }

        [TestMethod]
        public void Curso_Validation_True()
        {
            Curso = new Curso()
            {
                CodigoCurso = "2EF-2016"
            };
            var stubRepository = MockRepository.GenerateStub<ICursoRepository>();
            stubRepository.Stub(s => s.ObterPorCodigoCurso(Curso.CodigoCurso)).Return(null); // curso não encontrado - null

            var cursoValidation = new CursoCadastroValidation(stubRepository);
            Assert.IsTrue(cursoValidation.Validate(Curso).IsValid);
        }
        [TestMethod]
        public void Curso_Validation_False()
        {
            Curso = new Curso()
            {
                CodigoCurso = "2EF-2016"
            };
            var stubRepository = MockRepository.GenerateStub<ICursoRepository>();
            stubRepository.Stub(s => s.ObterPorCodigoCurso(Curso.CodigoCurso)).Return(Curso); // curso encontrado

            var cursoValidation = new CursoCadastroValidation(stubRepository);
            Assert.IsFalse(cursoValidation.Validate(Curso).IsValid);
        }
    }
}
