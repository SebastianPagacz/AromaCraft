using System;
using AromaCraft.Domain.Models;
using MediatR;

namespace AromaCraft.Application.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = Product.Create(request.Name, request.Price, request.WeightInGrams);

        return Result<Guid>.Success(newProduct.Id, "Product created.");
    }
}
