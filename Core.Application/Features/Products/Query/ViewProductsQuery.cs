using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Products.Query
{
    public class ViewProductsQuery : IRequest<Response<ViewProductsQueryResponse>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? Name { get; set; }
    }

    public class ViewProductsQueryHandler : IRequestHandler<ViewProductsQuery, Response<ViewProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public ViewProductsQueryHandler(IMapper mapper, IUnitOfWorks unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Response<ViewProductsQueryResponse>> Handle(ViewProductsQuery request, CancellationToken cancellationToken)
        {
            ViewProductsQueryResponse response = new ViewProductsQueryResponse();

            var productsAsQuery = await _unitOfWorks.ProductRead.GetAllQueryableAsync();
            productsAsQuery = productsAsQuery.Where(p => !p.IsDeleted);
            response.TotalCount = productsAsQuery.Count();

            if (request != null)
                productsAsQuery = productsAsQuery.Where(p => p.Name.ToLower().Contains(request.Name.ToLower()));

            if(request.PageSize.HasValue && request.PageNumber.HasValue)
                productsAsQuery = productsAsQuery.OrderByDescending(x => x.Id).Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                   .Take(request.PageSize.Value);

            response.Products = _mapper.Map<List<ProductDto>>(productsAsQuery);

            return new Response<ViewProductsQueryResponse>(response, null, true);
        }
    }

    public class ViewProductsQueryResponse
    {
        public List<ProductDto> Products { get; set; }
        public int TotalCount { get; set; }
    }
}
