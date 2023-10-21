using AppStore.Domain.Entities;

namespace AppStore.Domain.Repositories
{
    public interface ICategoryRepository : IUnitOfWork
    {
        Task AddAsync(Category category);
        Task<Category> GetByIdAsync(Guid categoryId);
        Task<Category> Update(Category category, Guid categoryId);
        Task<Category> Delete(Guid categoryId);
        Task<IEnumerable<Category>> GetCategories();

    }
}
