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
        entity.Created = DateTime.Now;
        await db.Todos.AddAsync(entity);
        await db.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await db.Todos.Where(t => t.Id == id).ExecuteDeleteAsync();
        await db.SaveChangesAsync();
    }
    public async Task UpdateAsync(Todo entity)
    {
        var toUpdate = db.Todos.FirstOrDefault(todo => todo.Id == entity.Id);
        if (toUpdate != null)
        {
            toUpdate.Title = entity.Title;
            toUpdate.Description = entity.Description;
            toUpdate.DaeadLine= entity.DaeadLine;
            toUpdate.IsReady = entity.IsReady;
            await db.SaveChangesAsync();    
        }
    }

    public async Task ReadyAsync(int id)
    {
        var toReady = db.Todos.FirstOrDefault(todo => todo.Id == id);
        if (toReady != null)
        {
            toReady.IsReady = true;
        }
        await db.SaveChangesAsync();
    }
}
