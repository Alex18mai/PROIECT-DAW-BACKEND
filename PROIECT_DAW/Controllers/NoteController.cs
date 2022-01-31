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
    public class NoteController : ControllerBase
    {
        private INotesManager notesManager;
        public NoteController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }


        [HttpGet("get-notes")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetNotes()
        {
            try
            {
                var note = notesManager.GetNotes().ToList();
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-note-by-id/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetNoteById([FromRoute] string id)
        {
            try
            {
                var note = notesManager.GetNoteById(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-note")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] NoteCreationModel model)
        {
            try
            {
                notesManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-note")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] NoteCreationModel model)
        {
            try
            {
                notesManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-note/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                notesManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
