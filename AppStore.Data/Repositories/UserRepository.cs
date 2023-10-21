using AppStore.Data.DataContext;
using AppStore.Domain.Entities;
using AppStore.Domain.Repositories;
using AppStore.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;
       
        public async Task AddAsync(User user)
        {
            try
            {              

                await _context.AddAsync(user);

            }
            catch (DbUpdateException)
            {

                throw new Exception("Erro ao inserir Usuário");
            }
        }

        public async Task<Response> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync().ConfigureAwait(false);
            return new Response(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<User> GetUserEmail(string email)
        {
            var existing = await _context.Users
              .Include(x => x.Roles)
              .FirstOrDefaultAsync(x => x.Email.Equals(email));

            if (existing is null)
                return null;

            return existing;
        }

        public async Task<User> GetUserId(Guid userId)
        {
            var existing = await _context.Users
               .AsTracking()
               .SingleOrDefaultAsync(x => x.Id.Equals(userId));

            if (existing is null)
                return null;

            return existing;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var listUsers = await _context.Users
                    .ToListAsync();

                if (listUsers is null)
                    return Enumerable.Empty<User>();

                return listUsers.AsReadOnly();
            }
            catch (DbUpdateException)
            {
                throw new Exception("Erro desconhecido ao acessar banco de dados");
            }
        }
    }
}
