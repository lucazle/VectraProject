using SistemaFuncionarios.Application.DTOs;
using SistemaFuncionarios.Domain.Entities;
using SistemaFuncionarios.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFuncionarios.Application.Services {
    public class FuncionarioService {

        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IDepartamentoRepository _departamentoRepository;

        public FuncionarioService(
            IFuncionarioRepository funcionarioRepository,
            IDepartamentoRepository departamentoRepository) 
        {
            _funcionarioRepository = funcionarioRepository;
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetAllAsync() {
            var funcionarios = await _funcionarioRepository.GetAllAsync();
            return funcionarios.Select(f => new FuncionarioDTO 
            {
                Id = f.Id,
                Nome = f.Nome,
                Cpf = f.Cpf,
                Email = f.Email,
                Salario = f.Salario,
                DataAdmissao = f.DataAdmissao,
                NomeDepartamento = f.Departamento?.Nome ?? "Sem departamento."
            });
        }

        public async Task<FuncionarioDTO?> GetByIdAsync(int id) {
            var funcionario = await _funcionarioRepository.GetByIdAsync(id);
            if (funcionario == null) return null;

            return new FuncionarioDTO {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf,
                Email = funcionario.Email,
                Salario = funcionario.Salario,
                DataAdmissao = funcionario.DataAdmissao,
                NomeDepartamento = funcionario.Departamento?.Nome ?? "Sem departamento."
            };
        }

        public async Task AddAsync(CreateFuncionarioDTO dto) {
            if (await _funcionarioRepository.CpfExisteAsync(dto.Cpf))
                throw new Exception("CPF já cadastrado");

            var departamento = await _departamentoRepository.GetByIdAsync(dto.DepartamentoId);
            if (departamento == null)
                throw new Exception("Departamento não encontrado");

            var funcionario = new Funcionario {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Salario = dto.Salario,
                DataAdmissao = dto.DataAdmissao,
                DepartamentoId = dto.DepartamentoId
            };

            await _funcionarioRepository.AddAsync(funcionario);
        }

        public async Task UpdateAsync(int id, UpdateFuncionarioDTO dto) {
            var funcionario = await _funcionarioRepository.GetByIdAsync(id);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado");

            var departamento = await _departamentoRepository.GetByIdAsync(dto.DepartamentoId);
            if (departamento == null)
                throw new Exception("Departamento não encontrado");

            funcionario.Nome = dto.Nome;
            funcionario.Email = dto.Email;
            funcionario.Salario = dto.Salario;
            funcionario.DepartamentoId = dto.DepartamentoId;

            await _funcionarioRepository.UpdateAsync(funcionario);
        }

        public async Task DeleteAsync(int id) {
            var funcionario = await _funcionarioRepository.GetByIdAsync(id);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado");

            await _funcionarioRepository.DeleteAsync(id);
        }
    }
}

