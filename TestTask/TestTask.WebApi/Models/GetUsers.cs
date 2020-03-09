using System.Collections.Generic;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Models
{
    public class GetUsers
    {
        public class Request { }

        public class Response : List<Response.Item>
        {
            public Response(IEnumerable<Response.Item> items) : base(items) { }

            public class Item
            {
                public int Id { get; set; }
                public string Email { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }

                public static Item FromDto(GetUsersResult.User user)
                {
                    return new Item
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                }
            }
        }
    }
}
