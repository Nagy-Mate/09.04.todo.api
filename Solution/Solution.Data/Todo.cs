namespace Solution.Data;

public class Todo
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public  DateTime DeadLine  { get; set; }   
    public DateTime Created { get; set; }
    public bool IsReady { get; set; }
}
