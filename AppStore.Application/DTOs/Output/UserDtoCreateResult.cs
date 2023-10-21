using AppStore.Domain.Entities;

namespace AppStore.Application.DTOs.Output
{
    public record UserDtoCreateResult(string FirstName, string LastName, string Email, string Password)
    {

        public static implicit operator UserDtoCreateResult(User entity)
            => new UserDtoCreateResult(entity.FirstName, entity.LastName, entity.Email, entity.PasswordHash);

        public static implicit operator User(UserDtoCreateResult dto)
           => new User(dto.FirstName, dto.LastName, dto.Email, dto.Password);
    }
}
