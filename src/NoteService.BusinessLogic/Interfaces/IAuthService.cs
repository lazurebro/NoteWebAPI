
using NoteService.DataAccessLayer.Models;

namespace NoteService.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUserAsync(string username, string email, string password);
        Task<string> LoginUserAsync(string username, string password);
    }
}
