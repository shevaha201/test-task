using System;

namespace TestTask.WebApi.Core.Entities
{
    public class UserAttempt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public int EnteredSecretValue { get; set; }
        public bool IsSuccess { get; set; }
    }
}
