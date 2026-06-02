namespace SistemaFuncionarios.Domain.Entities {
    public class Departamento {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Funcionario> Funcionarios { get; set; }
            = new List<Funcionario>();

    }
}
