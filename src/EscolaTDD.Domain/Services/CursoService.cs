using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Interfaces.Service;
using EscolaTDD.Domain.Validations.Cursos;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public Curso Adicionar(Curso curso)
        {
            curso.ValidationResult = new CursoCadastroValidation(_cursoRepository).Validate(curso);
            if (!curso.ValidationResult.IsValid)
            {
                return curso;
            }

            curso.ValidationResult.Message = "Curso cadastrado com sucesso!";
            return _cursoRepository.Adicionar(curso);
        }

        public Curso ObterPorId(Guid id)
        {
            return _cursoRepository.ObterPorId(id);
        }

        public IEnumerable<Curso> ObterTodos()
        {
            return _cursoRepository.ObterTodos();
        }

        public Curso Atualizar(Curso curso)
        {
            return _cursoRepository.Atualizar(curso);
        }

        public void Remover(Guid id)
        {
            _cursoRepository.Remover(id);
        }

        public Curso ObterPorAnoLetivo(int ano)
        {
            return _cursoRepository.ObterPorAnoLetivo(ano);
        }

        public Curso ObterPorCodigoCurso(string codigo)
        {
            return _cursoRepository.ObterPorCodigoCurso(codigo);
        }

        public string ObterCodigo(Guid id)
        {
            string codigo = _cursoRepository.ObterCodigo(id);
            return codigo.Split('-')[0];
        }

        public void Dispose()
        {
            _cursoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
