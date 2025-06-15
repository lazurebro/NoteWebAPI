using NoteService.DataAccessLayer.Models;

namespace NoteService.DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserListAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
