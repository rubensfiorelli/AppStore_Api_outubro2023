using AppStore.Application.DTOs.Input;
using AppStore.Application.DTOs.Output;

namespace AppStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDtoCreateResult> Add(CategoryDtoCreate model);
        Task<CategoryDtoCreateResult> GetId(Guid categoryId, CancellationToken ct);
        Task<IEnumerable<CategoryDtoCreateResult>> GetAll(CancellationToken ct);
        Task<CategoryDtoCreateResult> Update(Guid categoryId, CategoryDtoCreate model);
        Task<CategoryDtoCreateResult> Delete(Guid categoryId);
    }
}
