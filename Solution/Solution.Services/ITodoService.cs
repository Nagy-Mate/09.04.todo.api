using Solution.Data;

namespace Solution.Services
{
    public interface ITodoService
    {
        Task CreateAsync(Todo entity);
        Task<List<Todo>> ListAllAsync();
    }
}