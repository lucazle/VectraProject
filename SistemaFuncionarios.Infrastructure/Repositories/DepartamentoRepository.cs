using Microsoft.EntityFrameworkCore;
using SistemaFuncionarios.Domain.Entities;
using SistemaFuncionarios.Domain.Interfaces;
using SistemaFuncionarios.Infrastructure.Data;

namespace SistemaFuncionarios.Infrastructure.Repositories {
    public class DepartamentoRepository : IDepartamentoRepository {

        private readonly AppDbContext _context;

        public DepartamentoRepository (AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync() {
            return await _context.Departamentos
                .ToListAsync();
        }

        public async Task<Departamento?> GetByIdAsync(int id) {
            return await _context.Departamentos
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync (Departamento departamento) {
            await _context.Departamentos.AddAsync(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Departamento departamento) {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (int id) {
            var departamento = await GetByIdAsync(id);
            if (departamento != null) {
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
