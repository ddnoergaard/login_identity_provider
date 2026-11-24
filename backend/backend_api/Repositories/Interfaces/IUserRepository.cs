using backend_api.Models;

namespace backend_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task DeleteAsync(string firebaseUid);
        Task<User?> GetUserByFirebaseUid(string firebaseUid);
    }
}