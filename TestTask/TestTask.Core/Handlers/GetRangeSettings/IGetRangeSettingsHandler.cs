using System.Threading.Tasks;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Core.Handlers
{
    public interface IGetRangeSettingsHandler
    {
        Task<GetRangeSettingsResult> Handle();
    }
}
