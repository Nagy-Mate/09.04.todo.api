using Microsoft.EntityFrameworkCore;
using Solution.Data;

namespace Solution.Services;

public class TodoService(TodoDbContext db) : ITodoService
{
    public async Task<List<Todo>> ListAllAsync()
    {
        return await db.Todos.ToListAsync();
    }
    public async Task CreateAsync(Todo entity)
    {
        await db.Todos.AddAsync(entity);
        await db.SaveChangesAsync();
    }

}
