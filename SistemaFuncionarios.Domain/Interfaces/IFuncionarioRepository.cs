using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaFuncionarios.Domain.Entities;

namespace SistemaFuncionarios.Domain.Interface {
    public interface IFuncionarioRepository {

        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario?> GetByIdAsync(int id);
        Task AddAsync(Funcionario funcionario);
        Task UpdateAsync(Funcionario funcionario);
        Task DeleteAsync(int id);
        Task<bool> CPFExisteAsync(string cpf);

    }
}
