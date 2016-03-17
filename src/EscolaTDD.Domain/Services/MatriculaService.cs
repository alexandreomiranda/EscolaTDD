using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Interfaces.Service;
using EscolaTDD.Domain.Validations.Matriculas;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository,
                                ICursoRepository cursoRepository,
                                IAlunoRepository alunoRepository)
        {
            _matriculaRepository = matriculaRepository;
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
        }

        public Matricula Adicionar(Matricula matricula)
        {

            matricula.ValidationResult = new MatriculaCadastroValidation(_matriculaRepository).Validate(matricula);
            if (!matricula.ValidationResult.IsValid)
            {
                return matricula;
            }

            matricula.ValidationResult.Message = "Matrícula cadastrada com sucesso!";
            return _matriculaRepository.Adicionar(matricula);
        }

        public Matricula ObterPorId(Guid id)
        {
            return _matriculaRepository.ObterPorId(id);
        }

        public IEnumerable<Matricula> ObterTodos()
        {
            return _matriculaRepository.ObterTodos();
        }

        public Matricula Atualizar(Matricula matricula)
        {
            return _matriculaRepository.Atualizar(matricula);
        }

        public void Remover(Guid id)
        {
            _matriculaRepository.Remover(id);
        }

        public Matricula ObterMatriculaAlunoCurso(Guid aluno, Guid curso)
        {
            return _matriculaRepository.ObterMatriculaAlunoCurso(aluno, curso);
        }

        public bool ValidarFaixaEtariaPorCurso(Guid aluno, Guid curso)
        {
            int idade = _alunoRepository.ObterIdade(aluno);
            string codigo = _cursoRepository.ObterCodigo(curso);
            switch (codigo)
            {
                case "1EF":
                    return ((idade == 6 || idade == 7) ? true : false);
                case "2EF":
                    return ((idade == 7 || idade == 8) ? true : false);
                case "3EF":
                    return ((idade == 8 || idade == 9) ? true : false);
                case "4EF":
                    return ((idade == 9 || idade == 10) ? true : false);
                case "5EF":
                    return ((idade == 10 || idade == 11) ? true : false);
                case "6EF":
                    return ((idade == 11 || idade == 12) ? true : false);
                case "7EF":
                    return ((idade == 12 || idade == 13) ? true : false);
                case "8EF":
                    return ((idade == 13 || idade == 14) ? true : false);
                case "9EF":
                    return ((idade == 14 || idade == 15) ? true : false);
                case "1EM":
                    return ((idade == 15 || idade == 16) ? true : false);
                case "2EM":
                    return ((idade == 16 || idade == 17) ? true : false);
                case "3EM":
                    return ((idade == 17 || idade == 18) ? true : false);
                default:
                    return false;
            }

        }

        public void Dispose()
        {
            _matriculaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
