using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Handlers
{
    public class GetUserAttemptsHandler : IGetUserAttemptsHandler
    {
        private readonly IUserAttemptRepository _userAttemptRepository;

        public GetUserAttemptsHandler(IUserAttemptRepository userAttemptRepoistory)
        {
            _userAttemptRepository = userAttemptRepoistory;
        }

        public async Task<GetUserAttemptsResult> Handle(GetUserAttemptsParams getUserAttemptsParams)
        {
            ICollection<UserAttempt> userAttempts = await _userAttemptRepository.GetUserAttempts(getUserAttemptsParams.UserId);
            GetUserAttemptsResult result = new GetUserAttemptsResult(userAttempts.Select(Map).ToList());
            return result;
        }

        private static GetUserAttemptsResult.UserAttempt Map(UserAttempt userAttempt)
        {
            return new GetUserAttemptsResult.UserAttempt
            {
                Id = userAttempt.Id,
                DateTimeUtc = userAttempt.DateTimeUtc,
                IsSuccess = userAttempt.IsSuccess
            };
        }
    }
}
