using SistemaFuncionarios.Application.DTOs;
using SistemaFuncionarios.Domain.Entities;
using SistemaFuncionarios.Domain.Exceptions;
using SistemaFuncionarios.Domain.Interfaces;

namespace SistemaFuncionarios.Application.Services {
    public class DepartamentoService {

        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository) {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<DepartamentoDTO>> GetAllAsync() {
            var departamentos = await _departamentoRepository.GetAllAsync();
            return departamentos.Select(d => new DepartamentoDTO {
                Id = d.Id,
                Nome = d.Nome,
                Descricao = d.Descricao
            });
        }

        public async Task<DepartamentoDTO?> GetByIdAsync(int id) {
            var departamento = await _departamentoRepository.GetByIdAsync(id);
            if (departamento == null) return null;

            return new DepartamentoDTO {
                Id = departamento.Id,
                Nome = departamento.Nome,
                Descricao = departamento.Descricao

            };
        }

        public async Task AddAsync(CreateDepartamentoDTO dto) {

            var departamento = new Departamento {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            await _departamentoRepository.AddAsync(departamento);
        }

        public async Task UpdateAsync(int id, UpdateDepartamentoDTO dto) {
            {
                var departamento = await _departamentoRepository.GetByIdAsync(id);
                if (departamento == null)
                    throw new NotFoundException("Departamento não encontrado");

                departamento.Nome = dto.Nome;
                departamento.Descricao = dto.Descricao;

                await _departamentoRepository.UpdateAsync(departamento);
            }
        }
        public async Task DeleteAsync(int id) {
            var departamento = await _departamentoRepository.GetByIdAsync(id);
            if (departamento == null)
                throw new NotFoundException("Departamento não encontrado");

            await _departamentoRepository.DeleteAsync(id);
        }
    }
}
