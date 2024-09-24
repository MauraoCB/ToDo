using ToDo_API.Models;
using ToDo_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Task = System.Threading.Tasks.Task;
using System.Collections.Generic;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ToDo_API.Controllers
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
                        message = "Tarefa incluída com sucesso!",
                        success = true
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
        public async Task<ActionResult<Models.Task>> GetTask(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest( new { status = 400, message = "Id da tarefa deve ser fornecido" });
                }
                var task = _taskService.GetTask(id);

                return Ok(task);
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult<List<Models.Task>>> GetAll()
        {
            try
            {             
                var tasks = _taskService.GetAll();

                return Ok(tasks);
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTask")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult> UpdateTask([FromBody] Models.Task task)
        {
            try
            {
                 _taskService.UpdateTask(task);

                return Ok(new
                {
                    message = "Tarefa atualizada com sucesso!",
                    success = true
                });
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStatus/{id}/{status}")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult> UpdateStatus([FromBody] int id, string status )
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest(new { status = 400, message = "Id da tarefa deve ser fornecido" });
                }

                if ("P;C".IndexOf(status) < 0)
                {
                    return BadRequest(new { status = 400, message = "O status da tarefa deve ser P ou C" });
                }

                _taskService.UpdateStatus(id, status);

                return Ok(new
                {
                    message = "Status alterado com sucesso!",
                    success = true
                });
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTask/{id}")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest(new { status = 400, message = "Id da tarefa deve ser fornecido" });
                }
                 _taskService.DeleteTask(id);

                return Ok(new
                {
                    message = "Tarefa excluída com sucesso!",
                    success = true
                });
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
