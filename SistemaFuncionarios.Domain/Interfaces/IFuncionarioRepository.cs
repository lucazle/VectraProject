using SistemaFuncionarios.Domain.Entities;

namespace SistemaFuncionarios.Domain.Interfaces {
    public interface IFuncionarioRepository {

        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario?> GetByIdAsync(int id);
        Task AddAsync(Funcionario funcionario);
        Task UpdateAsync(Funcionario funcionario);
        Task DeleteAsync(int id);
        Task<bool> CpfExisteAsync(string cpf);
    }
}
