using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Data;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Entities;

namespace TestTask.WebApi.Core.Handlers
{
    public class GetRangeSettingsHandler : IGetRangeSettingsHandler
    {
        private readonly ISettingRepository _settingsRepository;

        public GetRangeSettingsHandler(ISettingRepository settingRepository)
        {
            _settingsRepository = settingRepository;
        }

        public async Task<GetRangeSettingsResult> Handle()
        {
            ICollection<Setting> settings = await _settingsRepository.GetSettings();

            ICollection<Setting> rangeSettings = settings
                .Where(t => t.Name == SettingName.SecretRangeMinValue || t.Name == SettingName.SecretRangeMaxValue)
                .ToList();

            GetRangeSettingsResult result = new GetRangeSettingsResult(rangeSettings.Select(Map).ToList());
            return result;
        }

        private static GetRangeSettingsResult.Setting Map(Setting setting)
        {
            return new GetRangeSettingsResult.Setting
            {
                Id = setting.Id,
                Name = setting.Name,
                IntValue = setting.IntValue
            };
        }
    }
}
