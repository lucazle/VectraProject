using SistemaFuncionarios.Domain.Entities;

namespace SistemaFuncionarios.Domain.Interfaces {
    public interface IDepartamentoRepository {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
        Task AddAsync(Departamento departamento);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(int id);
    }
}