using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Handlers
{
    public class AddUserAttemptsHandler : IAddUserAttemptHandler
    {
        private readonly IUserAttemptRepository _userAttemptRepository;
        private readonly ISettingRepository _settingsRepository;

        public AddUserAttemptsHandler(IUserAttemptRepository userAttemptRepoistory, ISettingRepository settingsRepository)
        {
            _userAttemptRepository = userAttemptRepoistory;
            _settingsRepository = settingsRepository;
        }

        public async Task<AddUserAttemptResult> Handle(AddUserAttemptParams addUserAttemptParams)
        {
            ICollection<Setting> settings = await _settingsRepository.GetSettings();

            // 1. Validate attempts count
            Setting enterSecretNumberAttemptsCountSetting = settings.Single(t => t.Name == SettingName.EnterSecretNumberAttemptsCount);
            int userAttemptsCount = (await _userAttemptRepository.GetUserAttempts(addUserAttemptParams.UserId)).Count;
            if (userAttemptsCount >= enterSecretNumberAttemptsCountSetting.IntValue)
                return new AddUserAttemptResult(AddUserAttemptResult.Type.AttemptsCountExceeded);

            // 2. Validate value against range
            Setting secretMinValueSetting = settings.Single(t => t.Name == SettingName.SecretRangeMinValue);
            if (addUserAttemptParams.SecretValue < secretMinValueSetting.IntValue)
                return new AddUserAttemptResult(AddUserAttemptResult.Type.LessThanRangeMinValue);

            Setting secretMaxValueSetting = settings.Single(t => t.Name == SettingName.SecretRangeMaxValue);
            if (addUserAttemptParams.SecretValue < secretMinValueSetting.IntValue)
                return new AddUserAttemptResult(AddUserAttemptResult.Type.MoreThanRangeMaxValue);

            // 3. Validate entered secret value
            AddUserAttemptResult result = null;

            Setting secretValueSetting = settings.Single(t => t.Name == SettingName.SecretValue);
            if (addUserAttemptParams.SecretValue == secretValueSetting.IntValue)
                result = new AddUserAttemptResult(AddUserAttemptResult.Type.Success);
            else
                result = new AddUserAttemptResult(AddUserAttemptResult.Type.IncorrectValue);

            // 4. Log user attempt to database
            UserAttempt userAttempt = new UserAttempt
            {
                UserId = addUserAttemptParams.UserId,
                DateTimeUtc = DateTime.UtcNow,
                EnteredSecretValue = addUserAttemptParams.SecretValue,
                IsSuccess = result.ResultType == AddUserAttemptResult.Type.Success
            };
            await _userAttemptRepository.AddUserAttempt(userAttempt);

            return result;
        }
    }
}
