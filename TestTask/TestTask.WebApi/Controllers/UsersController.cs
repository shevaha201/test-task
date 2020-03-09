using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.WebApi.Core.Dto;
using TestTask.WebApi.Core.Handlers;
using TestTask.WebApi.Models;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IGetUsersHandler _getUsersHandler;

        public UsersController(IGetUsersHandler getUsersHandler)
        {
            _getUsersHandler = getUsersHandler;
        }

        [HttpGet]
        public async Task<ActionResult<GetUsers.Response>> Get()
        {
            GetUsersResult getUsersResult = await _getUsersHandler.Handle();

            GetUsers.Response response = new GetUsers.Response(
                getUsersResult
                    .Select(t => GetUsers.Response.Item.FromDto(t))
                    .ToList()
            );

            return Ok(response);
        }
    }
}
