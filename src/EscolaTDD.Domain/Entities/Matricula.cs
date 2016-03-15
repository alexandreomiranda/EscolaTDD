using DomainValidation.Validation;
using EscolaTDD.Domain.Validations.Matriculas;
using System;

namespace EscolaTDD.Domain.Entities
{
    public class Matricula
    {
        public Matricula()
        {
            MatriculaId = Guid.NewGuid();
        }
        public Guid MatriculaId { get; set; }
        public Guid CursoId { get; set; }
        public Guid AlunoId { get; set; }
        public bool Status { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
