using System;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Core.Handlers
{
    public interface IAddUserAttemptHandler
    {
        Task<AddUserAttemptResult> Handle(AddUserAttemptParams addUserAttemptParams);
    }
}
