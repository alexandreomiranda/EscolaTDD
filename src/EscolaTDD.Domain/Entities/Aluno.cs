using DomainValidation.Validation;
using EscolaTDD.Domain.Validations.Alunos;
using System;
using System.Collections.Generic;


namespace EscolaTDD.Domain.Entities
{
    public class Aluno
    {
        public Aluno()
        {
            AlunoId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public ValidationResult ValidationResult { get; set; }
        
        public bool IsValid()
        {
            ValidationResult = new AlunoConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
    }

}
