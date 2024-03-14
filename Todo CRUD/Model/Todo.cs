namespace Todo_CRUD.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Task { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;   
    }
}
