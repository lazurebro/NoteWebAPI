using Microsoft.EntityFrameworkCore;
using NoteService.DataAccessLayer.Interfaces;
using NoteService.DataAccessLayer.Models;

namespace NoteService.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly NoteAppDbContext _db;

        public UserRepository(NoteAppDbContext db) {
            _db = db; 
        }

        public async Task<IEnumerable<User>> GetUserListAsync() =>
            await _db.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id) =>
            await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<User?> GetUserByUsernameAsync(string username) =>
            await _db.Users.FirstOrDefaultAsync(x => x.Username == username);

        public async Task CreateAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
