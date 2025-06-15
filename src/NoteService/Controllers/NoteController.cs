using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteService.BusinessLogic.DTO;
using NoteService.BusinessLogic.Interfaces;
using NoteService.DataAccessLayer.Models;
using NoteService.WebAPI.DTO;

namespace NoteService.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        private int GetUserIdFromContext() 
            => Convert.ToInt32(HttpContext.User.FindFirst("id")!.Value);
        
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var userId = GetUserIdFromContext();

            return Ok(await noteService.GetAllNotesAsync(userId));
        }

        [Route("{noteId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetNoteById([FromRoute] int noteId)
        {
            try
            {
                int userId = GetUserIdFromContext();
                NoteDTO noteDTO = await noteService.GetNoteByIdAsync(userId, noteId);
                return Ok(noteDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewNote([FromRoute] int noteId, [FromBody] CreateNoteDTO createNoteDTO)
        {
            int userId = GetUserIdFromContext();
            var noteDTO = await noteService.AddNoteAsync(userId, createNoteDTO.Title, createNoteDTO.Text);
            return Ok(noteDTO);
        }

        [Route("{noteId:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateExistNote([FromRoute] int noteId, [FromBody] UpdateNoteDTO updateNoteDTO)
        {
            try
            {
                int userId = GetUserIdFromContext();
                await noteService.UpdateNoteAsync(userId, noteId, updateNoteDTO.Title, updateNoteDTO.Text);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Route("{noteId:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteExistNote([FromRoute] int noteId)
        {
            try
            {
                int userId = GetUserIdFromContext();
                await noteService.DeleteNoteAsync(userId, noteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
