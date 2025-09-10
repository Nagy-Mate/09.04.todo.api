using Microsoft.EntityFrameworkCore;
using Solution.Data;

namespace Solution.Services;

public class TodoService(TodoDbContext db) : ITodoService
{
    public async Task<List<Todo>> ListAll()
    {
        return await db.Todos.ToListAsync();
    }
    public async Task Create(Todo entity)
    {
        await db.Todos.AddAsync(entity);
        await db.SaveChangesAsync();
    }

}
