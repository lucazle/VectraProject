using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFuncionarios.Application.DTOs {
    public class CreateFuncionarioDTO {

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Salário não pode ser negativo.")]
        public decimal Salario { get; set; }

        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Departamento é obrigatório.")]
        public int DepartamentoId { get; set; }
    }
}
