using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using testeTecnico.Interfaces;
using testeTecnico.Models;
using testeTecnico.Services;

namespace testeTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _context;

        public AlunoController(IAlunoService context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerResponse(201, "Aluno criado com sucesso", typeof(Aluno))]
        [SwaggerResponse(400, "Solicitação inválida")]
        [ProducesResponseType(typeof(Aluno), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAluno([FromBody] Aluno aluno)
        {

            if (aluno == null)
            {
                return BadRequest();
            }

            var alunoObject = await _context.AddAsync(aluno);
            

            return Ok(alunoObject);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, "Aluno encontrado", typeof(Aluno))]
        [SwaggerResponse(404, "Aluno não encontrado")]
        [ProducesResponseType(typeof(Aluno), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var alunoObject = await _context.GetByIdAsync(id);

            if (alunoObject == null)
            {
                return NotFound();
            }

            return Ok(alunoObject);
        }

        [HttpGet]
        [SwaggerResponse(200, "Buscar Todos Alunos", typeof(IEnumerable<Aluno>))]
        public async Task<IActionResult> BuscarTodos()
        {
            var alunosObject = await _context.GetAllAsync();
            return Ok(alunosObject);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(204, "Aluno atualizado com sucesso")]
        [SwaggerResponse(400, "Solicitação inválida")]
        [SwaggerResponse(404, "Aluno não encontrado")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAluno( int id, [FromBody] Aluno aluno)
        {
            var updatedAluno = await _context.UpdateAsync(id, aluno);
            if (updatedAluno == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204, "Aluno excluído com sucesso")]
        [SwaggerResponse(404, "Aluno não encontrado")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            await _context.DeleteAsync(id);
            return NoContent();
        }

    }
}
