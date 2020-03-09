using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Entities;

namespace TestTask.Infrastructure.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly string _conntectionString;

        public SettingRepository(IConfiguration configuration)
        {
            _conntectionString = configuration["Database:ConnectionString"];
        }

        public async Task<ICollection<Setting>> GetSettings()
        {
            ICollection<Setting> users = new List<Setting>();

            using (SqlConnection sqlConnection = new SqlConnection(_conntectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[spGetSettings]", sqlConnection))
                {
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        users.Add(new Setting
                        {
                            Id = (int)sqlDataReader["Id"],
                            Name = (string)sqlDataReader["Name"],
                            IntValue = (int)sqlDataReader["IntValue"],
                        });
                    }
                }
            }

            return users;
        }
    }
}
