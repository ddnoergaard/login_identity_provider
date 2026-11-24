using backend_api.Models;
using backend_api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace backend_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string _conString;

        public UserRepository(IConfiguration config)
        {
            _conString = config.GetConnectionString("Simply");
        }

        public async Task<User?> GetUserByFirebaseUid(string firebaseUid)
        {
            string sqlQuery = "SELECT * FROM Users WHERE FirebaseUid = @fbUid";

            using (SqlConnection con = new SqlConnection(_conString))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@fbUid", firebaseUid);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirebaseUid = Convert.ToString(reader["FirebaseUid"]),
                                DisplayName = reader["DisplayName"] == DBNull.Value ? null : Convert.ToString(reader["DisplayName"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                        return null;
                    }
                }

            }
        }

        public async Task<int> CreateAsync(User user)
        {
            string sqlStatement = "INSERT INTO Users(FirebaseUid, DisplayName) VALUES(@fbUid, @dName) RETURNING Id";

            using (SqlConnection con = new SqlConnection(_conString))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    cmd.Parameters.AddWithValue("@fbUid", user.FirebaseUid);
                    cmd.Parameters.AddWithValue("@dName", user.DisplayName);

                    return Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }

        public async Task DeleteAsync(string firebaseUid)
        {
            string sqlStatement = "DELETE FROM Users WHERE FirebaseUid = @fbUid";

            using (SqlConnection con = new SqlConnection(_conString))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    cmd.Parameters.AddWithValue("@fbUid", firebaseUid);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
