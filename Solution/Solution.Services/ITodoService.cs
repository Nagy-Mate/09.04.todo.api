using Solution.Data;

namespace Solution.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> Create(Todo entity);
        Task<List<Todo>> ListAll();
    }
}