using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NoteService.DataAccessLayer.Models;

namespace NoteService.DataAccessLayer.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> AddNoteAsync(Note note);
        Task<Note?> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllNotesAsync(User user);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(Note note);
    }
}
