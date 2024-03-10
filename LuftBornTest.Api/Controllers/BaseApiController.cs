using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuftBornTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        protected BaseApiController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        protected IMediator Mediator => _serviceProvider.GetRequiredService<IMediator>();
    }
}
