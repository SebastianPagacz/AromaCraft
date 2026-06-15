using System;
using AromaCraft.Domain.Exceptions;

namespace AromaCraft.Domain.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int WeightInGrams { get; private set; }

    private Product(string name, decimal price, int weightInGrams)
    {
        Name = name;
        Price = price;
        WeightInGrams = weightInGrams;
    }
    private Product()
    {
        
    }

    public static Result<Product> Create(string name, decimal price, int weightInGrams)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            return Result<Product>.Fail("Name can't be empty or exceed 255 characters.");

        if (price <= 0)
            return Result<Product>.Fail("Price can't be 0 or below.");

        if (weightInGrams < 0)
            return Result<Product>.Fail("Weight can't be negative."); // Left possibility for zero in case that the employee didn't know the exact weight therefore left as 0

        return Result<Product>.Success(new Product(name, price, weightInGrams), "Product created successfuly.");
    }

    public Result<Product> SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName) || newName.Length > 255)
            return Result<Product>.Fail("Name can't be empty or exceed 255 characters.");

        Name = newName;

        return Result<Product>.Success(this, "Product modified successfuly.");
    }

    public Result<Product> SetPrice(decimal newPrice)
    {
        if(newPrice <= 0)
            return Result<Product>.Fail("Price can't be 0 or below.");

        Price = newPrice;

        return Result<Product>.Success(this, "Product modified successfuly.");
    }

    public Result<Product> SetWeight(int newWeight)
    {
        if (newWeight < 0)
            return Result<Product>.Fail("Weight can't be negative.");

        WeightInGrams = newWeight;

        return Result<Product>.Success(this, "Product modified successfuly.");
    }
}
