using AppStore.Data.DataContext;
using AppStore.Domain.Entities;
using AppStore.Domain.Repositories;
using AppStore.Domain.Responses;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AppStore.Data.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) => _context = context;
        
        public async Task AddAsync(Category category)
        {
            try
            {
                var addEntity = await _context.Categories.AddAsync(category);

            }
            catch (DbException)
            {

                throw;
            }
        }      

        public async Task<Category> Delete(Guid categoryId)
        {
            try
            {
                var existing = await _context.Categories
                    .AsTracking()
                    .FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

                if (existing is null)
                    return null;

                existing.Delete();

                return existing;
            }
            catch (DbException)
            {

                throw;
            }
        }      

        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            try
            {
                var existing = await _context.Categories
                   .AsTracking()
                   .FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

                if (existing is null)
                    return null;

                return existing;
            }
            catch (DbException)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var listCategories = await _context.Categories
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

                if (listCategories is null)
                    return Enumerable.Empty<Category>();

                return listCategories.AsReadOnly();
            }
            catch (DbException)
            {

                throw;
            }
        }

        public async Task<Category> Update(Category category, Guid categoryId)
        {
            try
            {
                var existing = await _context.Categories
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(categoryId));

                if (existing is null)
                    return null;

                existing.UpdatedAt = DateTimeOffset.UtcNow;
                existing.CreatedAt = existing.CreatedAt;

                existing.SetupCategory(existing.Title, existing.Description);

                _context.Entry(existing).CurrentValues.SetValues(categoryId);

                return existing;

            }
            catch (DbException)
            {

                throw;
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

    }
}
