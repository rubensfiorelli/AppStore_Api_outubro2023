using AppStore.Domain.Responses;

namespace AppStore.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Response> Commit();
        
    }
}
