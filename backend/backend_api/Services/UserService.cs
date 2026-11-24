using backend_api.Models;
using backend_api.Repositories.Interfaces;
using backend_api.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace backend_api.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUserByFirebaseUid(string firebaseUid)
        {
            User? returnedUser = new();

            try
            {
                returnedUser = await _userRepo.GetUserByFirebaseUid(firebaseUid);
            }
            catch (SqlException ex)
            {
                throw new Exception("Something happened fetching a user", ex);
            }

            return returnedUser is null ? throw new KeyNotFoundException("No user with the Firebase Id found") : returnedUser;
        }

        public async Task<int> CreateAsync(User user)
        {
            int newInternalId = 0;

            if (user.DisplayName is null) user.DisplayName = GetRandomDisplayName(8);

            try
            {
                newInternalId = await _userRepo.CreateAsync(user);
            }
            catch (SqlException ex)
            {
                throw new Exception("Something happened creating a user", ex);
            }

            return newInternalId;
        }

        public async Task DeleteAsync(string firebaseUid)
        {
            try
            {
                await _userRepo.DeleteAsync(firebaseUid);
            }
            catch (SqlException ex)
            {
                throw new Exception("Something happened during deletion of user", ex);
            }
        }


        //Private methods
        private string GetRandomDisplayName(int length)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string returnString = "";
            Random rand = new Random();
            for (int i = 0; i <= length; i++)
            {
                returnString += characters[rand.Next(characters.Length)];
            }
            return returnString;
        }
    }
}
