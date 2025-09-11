using Solution.Data;

namespace Solution.Services
{
    public interface ITodoService
    {
        Task CreateAsync(Todo entity);
        Task DeleteAsync(int id);
        Task<List<Todo>> ListAllAsync();
        Task ReadyAsync(int id);
        Task UpdateAsync(Todo entity);
    }
}