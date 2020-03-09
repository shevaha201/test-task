using System.ComponentModel.DataAnnotations;

namespace TestTask.WebApi.Models
{
    public class PostUserAttempt
    {
        public class Request
        {
            [Required]
            public int? UserId { get; set; }

            [Required]
            public int? SecretValue { get; set; }
        }

        public class Response
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
