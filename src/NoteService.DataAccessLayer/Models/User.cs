namespace NoteService.DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; } = null!;
    }
}
