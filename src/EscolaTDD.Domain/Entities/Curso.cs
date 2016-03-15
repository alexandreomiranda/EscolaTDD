using System;
using System.Collections.Generic;
using EscolaTDD.Domain.Enum;

namespace EscolaTDD.Domain.Entities
{
    public class Curso
    {
        public Curso()
        {
            CursoId = Guid.NewGuid();
        }
        public Guid CursoId { get; set; }
        public string CodigoCurso { get; set; }
        public string TituloCurso { get; set; }
        public NivelEnsino NivelEnsino { get; set; }
        public Periodo Periodo { get; set; }
        public int AnoLetivo { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

    }
}
