using AppStore.Application.DTOs.Input;
using AppStore.Application.DTOs.Output;
using AppStore.Application.Interfaces;
using AppStore.Domain.Entities;
using AppStore.Domain.Repositories;

namespace AppStore.Application.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository) => _repository = repository;

        public async Task<CategoryDtoCreateResult> Add(CategoryDtoCreate model)
        {
            var addEntity = (Category)model;

            await _repository.AddAsync(addEntity);
            await _repository.Commit();

            return (CategoryDtoCreateResult)addEntity;

        }

        public async Task<CategoryDtoCreateResult> Delete(Guid categoryId)
        {

            var existing = await _repository.Delete(categoryId);
            await _repository.Commit();

            return existing;
        }

        public async Task<IEnumerable<CategoryDtoCreateResult>> GetAll(CancellationToken ct)
        {
            var listCategories = await _repository.GetCategories();

            return listCategories
                .Select(x => new CategoryDtoCreateResult(x.Id, x.Title, x.Description, x.Slug))
                .ToList();
        }
        public async Task<CategoryDtoCreateResult> GetId(Guid categoryId, CancellationToken ct)
        {
            var existing = await _repository.GetByIdAsync(categoryId);

            if (existing is null)
                return null;

            return existing;
        }

        public async Task<CategoryDtoCreateResult> Update(Guid categoryId, CategoryDtoCreate model)
        {         

            var existing = await _repository.GetByIdAsync(categoryId);

            if (existing is null)
                return null;

            existing.SetupCategory(model.Title, model.Description);

            await _repository.Update(existing, categoryId);
            await _repository.Commit();

            return (CategoryDtoCreateResult)existing;
        }
    }
}
