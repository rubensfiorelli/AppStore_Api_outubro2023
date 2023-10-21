using AppStore.Domain.Entities;

namespace AppStore.Application.DTOs.Input
{
    public record CategoryDtoCreate(string Title, string Description)
    {
        public static implicit operator Category(CategoryDtoCreate dto)
            => new(dto.Title, dto.Description);
    }
}
