using EscolaTDD.Domain.Entities;
using System;

namespace EscolaTDD.Domain.Interfaces.Repository
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        Matricula ObterMatriculaAlunoCurso(Guid aluno, Guid curso);
    }
}
