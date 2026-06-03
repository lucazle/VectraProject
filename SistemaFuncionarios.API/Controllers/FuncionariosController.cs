using Microsoft.AspNetCore.Mvc;
using SistemaFuncionarios.Application.DTOs;
using SistemaFuncionarios.Application.Services;

namespace SistemaFuncionarios.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase {

        private readonly FuncionarioService _funcionarioService;

        public FuncionariosController(FuncionarioService funcionarioService) {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var funcionarios = await _funcionarioService.GetAllAsync();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var funcionario = await _funcionarioService.GetByIdAsync(id);
            if (funcionario == null) return NotFound("Funcionário não encontrado.");
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFuncionarioDTO dto) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _funcionarioService.AddAsync(dto);
            return Created("", "Funcionário cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFuncionarioDTO dto) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _funcionarioService.UpdateAsync(id, dto);
            return Ok("Funcionário atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _funcionarioService.DeleteAsync(id);
            return Ok("Funcionário removido com sucesso!");
        }
    }
}