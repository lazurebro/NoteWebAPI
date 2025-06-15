using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.BusinessLogic.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
    }
}
