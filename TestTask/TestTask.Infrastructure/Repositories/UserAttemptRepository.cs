using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Entities;

namespace TestTask.Infrastructure.Repositories
{
    public class UserAttemptRepository : IUserAttemptRepository
    {
        private readonly string _conntectionString;

        public UserAttemptRepository(IConfiguration configuration)
        {
            _conntectionString = configuration["Database:ConnectionString"];
        }

        public async Task<ICollection<UserAttempt>> GetUserAttempts(int userId)
        {
            ICollection<UserAttempt> userAttempts = new List<UserAttempt>();

            using (SqlConnection sqlConnection = new SqlConnection(_conntectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[spGetUserAttempts]", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));

                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        userAttempts.Add(new UserAttempt
                        {
                            Id = (int)sqlDataReader["Id"],
                            UserId = (int)sqlDataReader["UserId"],
                            DateTimeUtc = (DateTime)sqlDataReader["DateTimeUtc"],
                            EnteredSecretValue = (int)sqlDataReader["EnteredSecretValue"],
                            IsSuccess = (bool)sqlDataReader["IsSuccess"],
                        });
                    }
                }
            }

            return userAttempts;
        }

        public async Task AddUserAttempt(UserAttempt userAttempt)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_conntectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[spAddUserAttempt]", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserId", userAttempt.UserId));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateTimeUtc", userAttempt.DateTimeUtc));
                    sqlCommand.Parameters.Add(new SqlParameter("@EnteredSecretValue", userAttempt.EnteredSecretValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsSuccess", userAttempt.IsSuccess));

                    await sqlCommand.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
