using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Data
{
    public interface IUserAttemptRepository
    {
        Task<ICollection<UserAttempt>> GetUserAttempts(int userId);
        Task AddUserAttempt(UserAttempt userAttempt);
    }
}
