using NoteService.BusinessLogic.DTO;
using NoteService.BusinessLogic.Interfaces;
using NoteService.DataAccessLayer.Interfaces;
using NoteService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.BusinessLogic.Services
{
    public class NoteService(
        INoteRepository noteRepository,
        IUserRepository userRepository
        ) : INoteService
    {
        public async Task<NoteDTO> AddNoteAsync(int userId, string name, string text)
        {
            var user = await userRepository.GetUserByIdAsync( userId );
            if (user == null)
                throw new Exception("User not found!");

            var note = new Note
            {
                Title = name,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                UserId = userId,
            };

            await noteRepository.AddNoteAsync(note);

            return new NoteDTO
            {
                Id = note.Id,
                Title = name,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
            };
        }

        public async Task<NoteDTO> GetNoteByIdAsync(int userId, int noteId)
        {
            User? user = await userRepository.GetUserByIdAsync( userId );
            if (user is null)
                throw new Exception("User with given id is not found!");

            Note? note = await noteRepository.GetNoteByIdAsync( noteId );
            if (note is null)
                throw new Exception("Note with given id not found!");
            if (note.UserId != userId)
                throw new Exception("Its not your note!");

            return new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Text = note.Text,
                CreatedDate = note.CreatedDate,
                EditedDate = note.EditedDate,
            };
        }

        public async Task<List<NoteDTO>> GetAllNotesAsync(int userId)
        {
            User? user = await userRepository.GetUserByIdAsync(userId);
            if (user is null)
                throw new Exception("User with given id is not found!");

            var notes = await noteRepository.GetAllNotesAsync(user);
            return notes
                .Select(note => new NoteDTO
                {
                    Id = note.Id,
                    Title = note.Title,
                    Text = note.Text,
                    CreatedDate = note.CreatedDate,
                    EditedDate = note.EditedDate,
                })
                .ToList();
        }

        public async Task UpdateNoteAsync(int userId, int noteId, string newTitle, string newText)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user is null)
                throw new Exception("User not found!");

            var note = await noteRepository.GetNoteByIdAsync(noteId);
            if (note is null)
                throw new Exception("Note with given id not found!");
            if (note.UserId !=  userId)
                throw new Exception("Its not your note!");

            note.Title = newTitle;
            note.Text = newText;
            note.EditedDate = DateTime.UtcNow;
            await noteRepository.UpdateNoteAsync(note);
        }

        public async Task DeleteNoteAsync(int userId, int noteId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user is null)
                throw new Exception("User not found!");

            var note = await noteRepository.GetNoteByIdAsync(noteId);
            if (note is null)
                throw new Exception("Note with given id not found!");
            if (note.UserId != userId)
                throw new Exception("Its not your note!");

            await noteRepository.DeleteNoteAsync(note);
        }
    }
}
