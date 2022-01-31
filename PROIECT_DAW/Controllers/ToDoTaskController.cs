using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROIECT_DAW.Managers;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private IToDoTasksManager todotasksManager;
        public ToDoTaskController(IToDoTasksManager todotasksManager)
        {
            this.todotasksManager = todotasksManager;
        }


        [HttpGet("get-todotasks")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetToDoTasks()
        {
            try
            {
                var todotasks = todotasksManager.GetToDoTasks().ToList();
                return Ok(todotasks);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-todotask-by-id/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetToDoTaskById([FromRoute] string id)
        {
            try
            {
                var todotask = todotasksManager.GetToDoTaskById(id);
                return Ok(todotask);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-todotasks-ordered-asc")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetToDoTasksOrderedAsc()
        {
            try
            {
                var todotasks = todotasksManager.GetToDoTasksOrderedAsc();
                return Ok(todotasks);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-number-of-tasks")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetNumberOfToDoTasks()
        {
            try
            {
                var numberoftasks = todotasksManager.GetNumberOfToDoTasks();
                return Ok(numberoftasks);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-todotask")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ToDoTaskCreationModel model)
        {
            try
            {
                todotasksManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-todotask")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ToDoTaskCreationModel model)
        {
            try
            {
                todotasksManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-todotask/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                todotasksManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
