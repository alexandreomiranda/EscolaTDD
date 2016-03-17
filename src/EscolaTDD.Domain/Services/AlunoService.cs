using EscolaTDD.Domain.Entities;
using EscolaTDD.Domain.Interfaces.Repository;
using EscolaTDD.Domain.Interfaces.Service;
using EscolaTDD.Domain.Validations.Alunos;
using System;
using System.Collections.Generic;

namespace EscolaTDD.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            if (!aluno.IsValid())
            {
                return aluno;
            }

            aluno.ValidationResult = new AlunoCadastroValidation(_alunoRepository).Validate(aluno);
            if (!aluno.ValidationResult.IsValid)
            {
                return aluno;
            }

            aluno.ValidationResult.Message = "Aluno cadastrado com sucesso :)";
            return _alunoRepository.Adicionar(aluno);
        }

        public Aluno ObterPorId(Guid id)
        {
            return _alunoRepository.ObterPorId(id);
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            return _alunoRepository.ObterTodos();
        }

        public Aluno Atualizar(Aluno aluno)
        {
            return _alunoRepository.Atualizar(aluno);
        }

        public void Remover(Guid id)
        {
            _alunoRepository.Remover(id);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _alunoRepository.ObterPorCpf(cpf);
        }

        public int ObterIdade(Guid id)
        {
            return _alunoRepository.ObterIdade(id);
        }

        public void Dispose()
        {
            _alunoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
