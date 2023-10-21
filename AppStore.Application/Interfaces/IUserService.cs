using AppStore.Application.DTOs.Input;
using AppStore.Application.DTOs.Output;

namespace AppStore.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDtoCreateResult>> GetUsers(CancellationToken ct);
        Task<UserDtoCreateResult> GetUserId(Guid userId, CancellationToken ct);
        Task<UserDtoCreateResult> GetUserEmail(string email, CancellationToken ct);
        Task Add(UserDtoCreate model);
    }
}
