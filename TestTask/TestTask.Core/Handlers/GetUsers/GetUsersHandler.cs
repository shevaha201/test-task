using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Handlers
{
    public class GetUsersHandler : IGetUsersHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepoistory)
        {
            _userRepository = userRepoistory;
        }

        public async Task<GetUsersResult> Handle()
        {
            ICollection<User> users = await _userRepository.GetUsers();
            GetUsersResult result = new GetUsersResult(users.Select(Map).ToList());
            return result;
        }

        private static GetUsersResult.User Map(User user)
        {
            return new GetUsersResult.User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
