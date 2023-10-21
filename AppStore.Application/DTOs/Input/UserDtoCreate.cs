using AppStore.Domain.Entities;

namespace AppStore.Application.DTOs.Input
{
    public record UserDtoCreate(string FirstName, string LastName, string Email, string PasswordHash)
    {
        public static implicit operator User(UserDtoCreate dto)
            => new User(dto.FirstName, dto.LastName, dto.Email, dto.PasswordHash);
        
    }
}
