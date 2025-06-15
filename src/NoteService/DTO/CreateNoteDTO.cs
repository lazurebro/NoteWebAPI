using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace NoteService.WebAPI.DTO
{
    public class CreateNoteDTO
    {
        public required string Title { get; set; }
        public required string Text { get; set; }
    }
}
