using AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Products.Query
{
    public class GetProductDetailsQuery : IRequest<Response<GetProductDetailsQueryResponse>>
    {
        public Guid id { get; set; }
    }

    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, Response<GetProductDetailsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public GetProductDetailsQueryHandler(IMapper mapper, IUnitOfWorks unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Response<GetProductDetailsQueryResponse>> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var existedProduct = await _unitOfWorks.ProductRead.GetAsync(p => p.Guid == request.id && !p.IsDeleted);

            if (existedProduct == null)
                return new Response<GetProductDetailsQueryResponse>(null, "Product could not be found", false);

            var result = _mapper.Map<GetProductDetailsQueryResponse>(existedProduct);
            return new Response<GetProductDetailsQueryResponse>(result, "Retrieved successfully", true);
        }
    }

    public class GetProductDetailsQueryResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
