using System;
using System.Collections.Generic;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Models
{
    public class GetUserAttempts
    {
        public class Request
        {
            public int? UserId { get; set; }
        }

        public class Response : List<Response.Item>
        {
            public Response(IEnumerable<Response.Item> items) : base(items) { }

            public class Item
            {
                public int Id { get; set; }
                public int UserId { get; set; }
                public DateTime DateTimeUtc { get; set; }
                public int EnteredSecretValue { get; set; }
                public bool IsSuccess { get; set; }

                public static Item FromDto(GetUserAttemptsResult.UserAttempt userAttempt)
                {
                    return new Item
                    {
                        Id = userAttempt.Id,
                        UserId = userAttempt.UserId,
                        DateTimeUtc = userAttempt.DateTimeUtc,
                        EnteredSecretValue = userAttempt.EnteredSecretValue,
                        IsSuccess = userAttempt.IsSuccess
                    };
                }
            }
        }
    }
}
