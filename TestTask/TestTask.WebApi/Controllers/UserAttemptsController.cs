using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Handlers;
using TestTask.WebApi.Models;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/userattempts")]
    public class UserAttemptsController : ControllerBase
    {
        private readonly IGetUserAttemptsHandler _getUserAttemptsHandler;
        private readonly IAddUserAttemptHandler _addUserAttemptHandler;

        public UserAttemptsController(IGetUserAttemptsHandler getUsersHandler, IAddUserAttemptHandler addUserAttemptHandler)
        {
            _getUserAttemptsHandler = getUsersHandler;
            _addUserAttemptHandler = addUserAttemptHandler;
        }

        [HttpGet]
        public async Task<ActionResult<GetUserAttempts.Response>> Get([FromQuery]GetUserAttempts.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetUserAttemptsResult getUserAttemptsResult = await _getUserAttemptsHandler.Handle(
                new GetUserAttemptsParams
                {
                    UserId = request.UserId.Value
                });

            GetUserAttempts.Response response = new GetUserAttempts.Response(
                getUserAttemptsResult
                    .Select(t => GetUserAttempts.Response.Item.FromDto(t))
                    .ToList()
            );

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PostUserAttempt.Response>> Post([FromBody] PostUserAttempt.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AddUserAttemptResult addUserAttemptResult = await _addUserAttemptHandler.Handle(
                new AddUserAttemptParams
                {
                    UserId = request.UserId.Value,
                    SecretValue = request.SecretValue.Value
                });

            if (addUserAttemptResult.ResultType == AddUserAttemptResult.Type.Success)
                return StatusCode(201, new PostUserAttempt.Response { IsSuccess = true });

            return StatusCode(201, new PostUserAttempt.Response { IsSuccess = false, ErrorMessage = addUserAttemptResult.ResultType.ToString() });
        }
    }
}
