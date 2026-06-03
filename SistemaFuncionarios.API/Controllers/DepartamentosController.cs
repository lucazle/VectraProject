using Microsoft.AspNetCore.Mvc;
using SistemaFuncionarios.Application.DTOs;
using SistemaFuncionarios.Application.Services;

namespace SistemaFuncionarios.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase {

        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(DepartamentoService departamentoService) {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var departamentos = await _departamentoService.GetAllAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var departamento = await _departamentoService.GetByIdAsync(id);
            if (departamento == null) return NotFound("Departamento não encontrado.");
            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartamentoDTO dto) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _departamentoService.AddAsync(dto);
            return Created("", "Departamento cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartamentoDTO dto) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _departamentoService.UpdateAsync(id, dto);
            return Ok("Departamento atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _departamentoService.DeleteAsync(id);
            return Ok("Departamento removido com sucesso!");
        }
    }
}
