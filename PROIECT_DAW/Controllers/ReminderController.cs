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
    public class ReminderController : ControllerBase
    {
        private IRemindersManager remindersManager;
        public ReminderController(IRemindersManager remindersManager)
        {
            this.remindersManager = remindersManager;
        }


        [HttpGet("get-reminders")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetReminders()
        {
            try
            {
                var reminder = remindersManager.GetReminders().ToList();
                return Ok(reminder);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-reminder-by-id/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetReminderById([FromRoute] string id)
        {
            try
            {
                var reminder = remindersManager.GetReminderById(id);
                return Ok(reminder);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-reminder")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ReminderCreationModel model)
        {
            try
            {
                remindersManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-reminder")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ReminderCreationModel model)
        {
            try
            {
                remindersManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-reminder/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                remindersManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
