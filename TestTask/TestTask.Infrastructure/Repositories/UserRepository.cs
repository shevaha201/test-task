using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Entities;

namespace TestTask.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _conntectionString;

        public UserRepository(IConfiguration configuration)
        {
            _conntectionString = configuration["Database:ConnectionString"];
        }

        public async Task<ICollection<User>> GetUsers()
        {
            ICollection<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(_conntectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[spGetUsers]", sqlConnection))
                {
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        users.Add(new User
                        {
                            Id = (int)sqlDataReader["Id"],
                            Email = (string)sqlDataReader["Email"],
                            FirstName = (string)sqlDataReader["FirstName"],
                            LastName = (string)sqlDataReader["LastName"]
                        });
                    }
                }
            }

            return users;
        }
    }
}
