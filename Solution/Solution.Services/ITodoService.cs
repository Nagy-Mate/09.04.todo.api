using Solution.Data;

namespace Solution.Services
{
    public interface ITodoService
    {
        Task CreateAsync(Todo entity);
        Task DeleteAsync(int id);
        Task<List<Todo>> ListAllAsync();
        Task<List<Todo>> ListNotReadyAsync();
        Task ReadyAsync(int id);
        Task UpdateAsync(Todo entity);
        Task<Todo> GetTodoByIdAsync(int id);
    }
}