using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.DataAccessLayer.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
    }
}
