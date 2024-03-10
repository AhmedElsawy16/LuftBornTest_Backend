using Core.Application.Features.Products.Command;
using Core.Application.Features.Products.Query;
using Core.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuftBornTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        public ProductsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost("Create")]
        public async Task<Response<Guid>> CreateProduct([FromBody] CreateProductCommand request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Get")]
        public async Task<Response<ViewProductsQueryResponse>> GetProducts([FromBody] ViewProductsQuery request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<Response<UpdateProductCommandResponse>> UpdateProduct([FromBody] UpdateProductCommand request)
        {
            return await Mediator.Send(request);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<Response<Guid>> Block(Guid id)
        {
            DeleteProductCommand request = new DeleteProductCommand() { guid = id };
            return await Mediator.Send(request);
        }

        [HttpGet("Get/{id}")]
        public async Task<Response<GetProductDetailsQueryResponse>> GetProducts(Guid id)
        {
            GetProductDetailsQuery request = new GetProductDetailsQuery() { id = id };
            return await Mediator.Send(request);
        }
    }
}
