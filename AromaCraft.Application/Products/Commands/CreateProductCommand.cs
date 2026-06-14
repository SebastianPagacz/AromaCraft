using System;
using AromaCraft.Domain.Models;
using MediatR;

namespace AromaCraft.Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price, int WeightInGrams) : IRequest<Result<Guid>> { }