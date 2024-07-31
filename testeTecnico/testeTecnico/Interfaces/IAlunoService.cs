using testeTecnico.Models;

namespace testeTecnico.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno> GetByIdAsync(int id);
        Task<Aluno> AddAsync(Aluno aluno);
        Task<Aluno> UpdateAsync(int id, Aluno aluno);
        Task DeleteAsync(int id);
    }
}
