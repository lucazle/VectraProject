using Microsoft.EntityFrameworkCore;
using SistemaFuncionarios.Domain.Entities;

namespace SistemaFuncionarios.Infrastructure.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Funcionario>(entity => {

                entity.HasKey(f => f.Id);
                entity.Property(f => f.Nome).IsRequired().HasMaxLength(100);
                entity.Property(f => f.Cpf).IsRequired().HasMaxLength(11);
                entity.HasIndex(f => f.Cpf).IsUnique();
                entity.HasIndex(f => f.Email).IsUnique();
                entity.Property(f => f.Salario).HasPrecision(10, 2);
                entity.HasOne(f => f.Departamento)
                      .WithMany(d => d.Funcionarios)
                      .HasForeignKey(f => f.DepartamentoId);
            });

            modelBuilder.Entity<Departamento>(entity => {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Nome).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Descricao).HasMaxLength(255);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
