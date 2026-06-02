namespace SistemaFuncionarios.Domain.Entities {
    public class Funcionario {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int DepartamentoId { get; set; }

        public Departamento? Departamento { get; set; }
    }
}
