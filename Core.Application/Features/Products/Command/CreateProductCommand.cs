using AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Application.Wrappers;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Features.Products.Command
{
    public class CreateProductCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomepage { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWorks unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Response<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.Guid = Guid.NewGuid();
            await _unitOfWorks.ProductWrite.AddAsync(product);
            await _unitOfWorks.SaveAsync();

            return new Response<Guid>(product.Guid, "Product has been created successfully", true);
        }
    }
}
