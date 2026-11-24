using backend_api.Models;

namespace backend_api.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(User user);
        Task DeleteAsync(string firebaseUid);
        Task<User> GetUserByFirebaseUid(string firebaseUid);
    }
}