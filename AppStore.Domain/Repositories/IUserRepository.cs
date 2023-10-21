using AppStore.Domain.Entities;

namespace AppStore.Domain.Repositories
{
    public interface IUserRepository : IUnitOfWork
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserId(Guid userId);
        Task<User> GetUserEmail(string email);
       
    }
}
