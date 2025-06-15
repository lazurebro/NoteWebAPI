using Microsoft.AspNetCore.Identity;
using NoteService.BusinessLogic.Interfaces;
using NoteService.DataAccessLayer.Interfaces;
using NoteService.DataAccessLayer.Models;
using System.Runtime.CompilerServices;

namespace NoteService.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly JwtService jwtService;

        public AuthService(IUserRepository userRepository, JwtService jwtService)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }

        public async Task RegisterUserAsync(string username, string email, string password)
        {
            var exUser = await userRepository.GetUserByUsernameAsync(username);
            if (exUser != null)
                throw new Exception("User with given username is now exists!");

            var user = new User
            {
                Username = username,
                Email = email,
            };

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);

            await userRepository.CreateAsync(user);
        }

        public async Task<string> LoginUserAsync(string username, string password)
        {
            User? user = await userRepository.GetUserByUsernameAsync(username);
            if (user == null)
                throw new Exception("User not found!");

            var matchPasswordResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
            if (matchPasswordResult == PasswordVerificationResult.Success) 
            {
                return jwtService.GenerateToken(user);
            }
            else
                throw new Exception("Invalid password!");
        }
    }
}
