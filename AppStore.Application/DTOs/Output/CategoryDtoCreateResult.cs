using AppStore.Domain.Entities;

namespace AppStore.Application.DTOs.Output
{
    public record CategoryDtoCreateResult(Guid Id, string Title, string Description, string Slug)
    {
        public static implicit operator CategoryDtoCreateResult(Category entity)
            => new(entity.Id, entity.Title, entity.Description, entity.Slug);
    }
}
