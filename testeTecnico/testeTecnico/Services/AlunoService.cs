using testeTecnico.Interfaces;
using testeTecnico.Models;
using testeTecnico.Repository;

namespace testeTecnico.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AlunoRepository _context;

        public AlunoService(AlunoRepository context)
        {
            _context = context;
        }
        public async Task<Aluno> AddAsync(Aluno aluno)
        {
            await _context.AddAsync(aluno);
            return aluno;
        }

        public async Task DeleteAsync(int id)
        {
            await _context.DeleteAsync(id);
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task<Aluno> UpdateAsync(int id, Aluno alunoUpdate)
        {
            var aluno = await _context.GetByIdAsync(id);

            if (aluno == null)
            {
                return null;
            }

            await _context.UpdateAsync(aluno);
            return aluno;
        }
    }
}
