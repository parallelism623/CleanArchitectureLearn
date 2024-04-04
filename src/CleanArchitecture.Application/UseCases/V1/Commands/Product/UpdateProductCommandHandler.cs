using AutoMapper;
using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Abstractions.Repositories;
using CleanArchitecture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductFunction = CleanArchitecture.Contract.Services.Product;

namespace CleanArchitecture.Application.UseCases.V1.Commands.Product
{
    public class UpdateProductCommandHandler : ICommandHandler<ProductFunction.Command.UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository,
                                           IMapper mapper,
                                           IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var exception = new ProductException.NotFound(request.Id);
            var product = await _productRepository.FindByIdAsync(request.Id) ?? throw exception;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Name = request.Name;
            await _unitOfWork.CommitAsync();
            return Result.Success();
        }
    }
}
