using System.Collections.Generic;

namespace TestTask.WebApi.Core.Dto
{
    public class GetUsersResult : List<GetUsersResult.User>
    {
        public GetUsersResult(IEnumerable<GetUsersResult.User> items) : base(items) { }

        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
