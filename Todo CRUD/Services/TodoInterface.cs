using Todo_CRUD.Model;

namespace Todo_CRUD.Services
{
    public interface TodoInterface
    {
        List<Todo> GetAllTodo(bool? IsDone);
        Todo? GetTodo(int id);
        Todo AddTodo(UpdateTodo obj);
        Todo? UpdateTodoList(int id, UpdateTodo obj);
        bool DeleteTodo(int id);
    }
}
