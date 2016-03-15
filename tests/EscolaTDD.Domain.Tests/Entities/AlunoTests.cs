using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscolaTDD.Domain.Entities;

namespace EscolaTDD.Domain.Tests.Entities
{
    [TestClass]
    public class AlunoTests
    {
        public Aluno Aluno { get; set; }

        [TestMethod]
        public void Aluno_Consistente_True()
        {
            Aluno = new Aluno()
            {
                CPF = "65560639834", //informando CPF válido
                DataNascimento = new DateTime(1998, 01, 01) // informando data nascimento válida para cadastro
            };
            Assert.IsTrue(Aluno.IsValid());
        }

        [TestMethod]
        public void Aluno_Consistente_False()
        {
            Aluno = new Aluno()
            {
                CPF = "65560639800", //informando CPF inválido
                DataNascimento = new DateTime(1997, 01, 01) // informando data nascimento inválida 
            };
            Assert.IsFalse(Aluno.IsValid());
            Assert.IsTrue(Aluno.ValidationResult.Erros.Any(e => e.Message == "Aluno informou um CPF inválido."));
            Assert.IsTrue(Aluno.ValidationResult.Erros.Any(e => e.Message == "Aluno não se enquadra na faixa etária da escola."));
        }
    }
}
