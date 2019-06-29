using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskWebApp.DAT;
using TaskWebApp.Model;

namespace TaskWebApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IContext _context;
        public TaskController(IContext context, ILogger<TaskController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        [HttpGet]
        [Route("AllTasks")]
        public IActionResult GetAllTasks()
        {
            try
            {
                return Ok(_context.GetAllTodoTasks());
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method GetAllTasks report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot send all tasks");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod GetAllTask report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }
            
        }
        [HttpGet]
        [Route("GetTaskById/{taskid}")]
        public IActionResult GetTaskById(string taskid )
        {
            TodoTask taskDetail = null ;
            try
            {
                taskDetail = _context.GetTaskById(taskid);
                if (taskDetail == null)
                    return NotFound();

            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method GetTaskById report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot find single task, provided data are incorrect");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod GetTaskById report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }

            return Ok(taskDetail);
        }
        [HttpPost]
        [Route("InsertTask")]
        public IActionResult PostTodoTask(TodoTask source)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.CreateTask(source);
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method PostTodoTask report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot creat new task, provided data are incorrect");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod PostTodoTask report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }
            return Ok(source);
        }
        [HttpPut]
        [Route("UpdateTask")]
        public IActionResult PutTodoTask(TodoTask source)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                _context.UpdateTaskProperties(source);
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method PutTodoTask report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot update task, provided data are incorrect");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod PutTodoTask report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }
            return Ok(source);
        }
        [HttpDelete]
        [Route("DeleteTask/{taskid}")]
        public IActionResult DeleteTask(string taskid)
        {

            if (_context.GetTaskById(taskid) == null)
                return NotFound();
            try
            {
                _context.RemoveTaskById(taskid);
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method DeleteTask report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot delete task");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod DeleteTask report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }
            return Ok();
        }

        [HttpPost]
        [Route("ChangeStateTask/{taskid}")]
        public IActionResult ChangeStateTask(string taskid)
        {
            if (_context.GetTaskById(taskid) == null)
                return NotFound();

            try
            {
                _context.ChangeTaskFieldIsFinshed(taskid);
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Method ChangeStateTask report  SQL Server error, details:\n\t{ex.Message}");
                return BadRequest("Cannot change tast state execution");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Metod ChangeStateTask report unknow error details:\n\t{ex.Message}");
                return BadRequest("Unknow error occured");
            }
            return Ok();
        }
    }
}
