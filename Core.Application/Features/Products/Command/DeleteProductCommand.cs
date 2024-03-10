using AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Products.Command
{
    public class DeleteProductCommand : IRequest<Response<Guid>>
    {
        public Guid guid { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWorks unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Response<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existedProduct = await _unitOfWorks.ProductRead.GetAsync(p => p.Guid == request.guid);

            if (existedProduct == null)
                return new Response<Guid>(Guid.Empty, "Product could not be found", false);

            existedProduct.IsDeleted = true;
            await _unitOfWorks.ProductWrite.UpdateAsync(existedProduct);
            await _unitOfWorks.SaveAsync();

            return new Response<Guid>(existedProduct.Guid, "Product Deleted Successfully", true);
        }
    }
}
