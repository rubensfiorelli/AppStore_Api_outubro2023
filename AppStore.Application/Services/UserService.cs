using AppStore.Application.DTOs.Input;
using AppStore.Application.DTOs.Output;
using AppStore.Application.Interfaces;
using AppStore.Domain.Entities;
using AppStore.Domain.Repositories;
using SecureIdentity.Password;

namespace AppStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task Add(UserDtoCreate model)
        {
            var passwordHash = model.PasswordHash;

            var addEntity = (User)model;

            var passowrd = PasswordHasher.Hash(passwordHash);

            addEntity.SetPassword(passowrd);                

            await _userRepository.AddAsync(addEntity);
            _ = await _userRepository.Commit();

        }     

        public async Task<UserDtoCreateResult> GetUserEmail(string email, CancellationToken ct)
        {
            var existing = await _userRepository.GetUserEmail(email);

            if (existing is not null)
                return (UserDtoCreateResult)existing;

            return null;
        }

        public async Task<UserDtoCreateResult> GetUserId(Guid userId, CancellationToken ct)
        {
            var existing = await _userRepository.GetUserId(userId);

            if (existing is null)
                return null;

            return (UserDtoCreateResult)existing; ;
        }

        public async Task<List<UserDtoCreateResult>> GetUsers(CancellationToken ct)
        {
            var listUsers = await _userRepository.GetUsers();

            return listUsers
                .Select(x => new UserDtoCreateResult(x.FirstName, x.LastName, x.Email, x.PasswordHash))
                .ToList();
        }
    }
}
