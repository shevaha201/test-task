using System;
using System.Collections.Generic;

namespace TestTask.WebApi.Core.Dto
{
    public class GetUserAttemptsResult : List<GetUserAttemptsResult.UserAttempt>
    {
        public GetUserAttemptsResult(IEnumerable<GetUserAttemptsResult.UserAttempt> items) : base(items) { }

        public class UserAttempt
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public DateTime DateTimeUtc { get; set; }
            public int EnteredSecretValue { get; set; }
            public bool IsSuccess { get; set; }
        }
    }
}
