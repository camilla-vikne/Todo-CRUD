using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo_CRUD.Model;
using Todo_CRUD.Services;

namespace Todo_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoInterface _todoInterface;
        public TodoController (TodoInterface todoInterface)
        {
            _todoInterface = todoInterface;
        }
        [HttpGet]
        public ActionResult Get([FromQuery] bool? IsDone = null) 
        {
            return Ok(_todoInterface.GetAllTodo(IsDone));
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _todoInterface.GetTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
        [HttpPost]
        public IActionResult Post(UpdateTodo todoObject)
        {
            var todo = _todoInterface.AddTodo(todoObject);
            if (todo == null)
            {
                return BadRequest();

            }
            return Ok(new
            {
                message = "Task created successfully",
                id = todo.Id
            });
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UpdateTodo todoObject)
        {
            var todo = _todoInterface.UpdateTodoList(id, todoObject);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Task updated successfully",
                id = todo!.Id
            });
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_todoInterface.DeleteTodo(id))
            {
                return NotFound();

            }
            return Ok(new
            {
                message = "Task deleted successfully",
                id = id
            });
        }

    }
}
// Project created with help from https://www.c-sharpcorner.com/article/net-8-web-api-crud-operations/
