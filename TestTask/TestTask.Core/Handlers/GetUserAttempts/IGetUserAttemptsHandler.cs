using System;
using System.Threading.Tasks;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Core.Handlers
{
    public interface IGetUserAttemptsHandler
    {
        Task<GetUserAttemptsResult> Handle(GetUserAttemptsParams getUserAttemptsParams);
    }
}
