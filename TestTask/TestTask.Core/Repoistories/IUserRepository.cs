using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Data
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
    }
}
