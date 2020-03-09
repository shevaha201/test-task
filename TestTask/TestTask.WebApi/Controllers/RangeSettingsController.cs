using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Handlers;
using TestTask.WebApi.Models;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/rangesettings")]
    public class RangeSettingsController : ControllerBase
    {
        private readonly IGetRangeSettingsHandler _getSettingsHandler;

        public RangeSettingsController(IGetRangeSettingsHandler getUsersHandler)
        {
            _getSettingsHandler = getUsersHandler;
        }

        [HttpGet]
        public async Task<ActionResult<GetRangeSettings.Response>> Get()
        {
            GetRangeSettingsResult getUsersResult = await _getSettingsHandler.Handle();

            GetRangeSettings.Response response = new GetRangeSettings.Response(
                getUsersResult
                    .Select(t => GetRangeSettings.Response.Item.FromDto(t))
                    .ToList()
            );

            return Ok(response);
        }
    }
}
