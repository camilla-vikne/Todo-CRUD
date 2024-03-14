using System.Reflection;
using Todo_CRUD.Model;

namespace Todo_CRUD.Services
{
    public class TodoActions : TodoInterface
    {
        private readonly List<Todo> _todoList;
        public TodoActions()
        {
            _todoList = new List<Todo>()
            {
                new Todo()
                {
                    Id = 1,
                    Title = "",
                    Task = "",
                    IsDone = false,

                }
            };
        }
        public List<Todo> GetAllTodo(bool? IsDone)
        {
            return IsDone == null ? _todoList : _todoList.Where(todo => todo.IsDone == IsDone).ToList();

        }
        public Todo? GetTodo(int id) 
        {
            return _todoList.FirstOrDefault(todo => todo.Id == id);
        }
        public Todo AddTodo(UpdateTodo obj)
        {
            var addTodoItem = new Todo()
            {
                Id = _todoList.Max(todo => todo.Id) + 1,
                Title = obj.Title,
                Task = obj.Task,
                IsDone = obj.IsDone,
            };
            _todoList.Add(addTodoItem);
            return addTodoItem;
        }
        public Todo? UpdateTodoList(int id, UpdateTodo obj)
        {
            var TodoIndex = _todoList.FindIndex(index => index.Id == id);
            if (TodoIndex == 0)
            {
                var todo = _todoList[TodoIndex];
                todo.Title = obj.Title;
                todo.Task = obj.Task;
                todo.IsDone = obj.IsDone;

                _todoList[TodoIndex] = todo;
                return todo;
            }
            else
            {
                return null;
            }
       
        }
        public bool DeleteTodo(int id)
        {
            var TodoIndex = _todoList.FindIndex(index => index.Id == id);
            if (TodoIndex >= 0)
            {
                _todoList.RemoveAt(TodoIndex);
            }
            return TodoIndex >= 0;
        }
    }
}
