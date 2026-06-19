using System;
using AromaCraft.Domain.Models;
using AromaCraft.Domain.Repository;
using MediatR;

namespace AromaCraft.Application.Products.Commands;

public class CreateProductHandler(IRepository<Product> _repository, IUnitOfWork _uow) : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = Product.Create(request.Name, request.Price, request.WeightInGrams);

        if (newProduct.IsFailed)
            return Result<Guid>.Fail(newProduct.Message);

        _repository.Add(newProduct.Value);
        await _uow.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(newProduct.Value.Id);
    }
}
