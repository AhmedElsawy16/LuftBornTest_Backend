using AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Application.Wrappers;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Features.Products.Command
{
    public class UpdateProductCommand : IRequest<Response<UpdateProductCommandResponse>>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomepage { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<UpdateProductCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWorks unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Response<UpdateProductCommandResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existedProduct = await _unitOfWorks.ProductRead.GetAsync(p => p.Guid == request.Guid);
            if (existedProduct == null)
                return new Response<UpdateProductCommandResponse>(null, "Product could not be found", false);

            _mapper.Map<UpdateProductCommand, Product>(request, existedProduct);
            await _unitOfWorks.ProductWrite.UpdateAsync(existedProduct);
            await _unitOfWorks.SaveAsync();

            return new Response<UpdateProductCommandResponse>(_mapper.Map<UpdateProductCommandResponse>(existedProduct), "Product Updated Successfully", true);
        }
    }

    public class UpdateProductCommandResponse
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomepage { get; set; }
    }
}
