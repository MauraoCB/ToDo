using TopDown_API.Models;
using TopDown_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Task = System.Threading.Tasks.Task;

namespace TopDown_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("AddTask")]
        [Authorize(Roles = "Usuario")]
        public IActionResult AddTask([FromBody] Models.Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _taskService.AddTask(task);

                    return Ok(new
                    {
                        Message = "Tarefa incluída com sucesso!",
                        Success = true
                    });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTask/{id}")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult<Task>> GetTask(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Problem(statusCode: 500, detail: "Id da tarefa deve ser fornecido");
                }
                var task = _taskService.GetTask(id);

                return Ok(task);
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
