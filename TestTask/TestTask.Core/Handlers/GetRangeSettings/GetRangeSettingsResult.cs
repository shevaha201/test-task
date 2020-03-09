using System.Collections.Generic;

namespace TestTask.WebApi.Core.Dto
{
    public class GetRangeSettingsResult : List<GetRangeSettingsResult.Setting>
    {
        public GetRangeSettingsResult(IEnumerable<GetRangeSettingsResult.Setting> items) : base(items) { }

        public class Setting
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int IntValue { get; set; }
        }
    }
}
