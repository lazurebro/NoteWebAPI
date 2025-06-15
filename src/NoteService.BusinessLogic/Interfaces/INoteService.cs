using NoteService.BusinessLogic.DTO;
using NoteService.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.BusinessLogic.Interfaces
{
    public interface INoteService
    {
        Task<NoteDTO> AddNoteAsync(int userId, string name, string text);
        Task<NoteDTO> GetNoteByIdAsync(int userId, int noteId);
        Task<List<NoteDTO>> GetAllNotesAsync(int userId);
        Task UpdateNoteAsync(int userId, int id, string newTitle, string newText);
        Task DeleteNoteAsync(int userId, int id);
    }
}
