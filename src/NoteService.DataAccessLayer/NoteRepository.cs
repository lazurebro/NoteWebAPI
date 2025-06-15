using Microsoft.EntityFrameworkCore;
using NoteService.DataAccessLayer.Interfaces;
using NoteService.DataAccessLayer.Models;

namespace NoteService.DataAccessLayer
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteAppDbContext _db;

        public NoteRepository(NoteAppDbContext db)
        {
            this._db = db;
        }

        public async Task<Note> AddNoteAsync(Note newNote)
        {
            await _db.Notes.AddAsync(newNote);
            await _db.SaveChangesAsync();
            return newNote;
        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            var note = await _db.Notes.FindAsync(id);
            return note;
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync(User user)
        {
            var notes = await _db.Notes
                .Where(n => n.UserId == user.Id)
                .ToListAsync();
            return notes;
        }

        public async Task UpdateNoteAsync(Note note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(Note note)
        {
            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();
        }
    }
}
