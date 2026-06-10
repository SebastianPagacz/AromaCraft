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

    public static Product Create(string name, decimal price, int weightInGrams)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            throw new DomainException("Name can't be empty or exceed 255 characters."); 

        if (price <= 0)
            throw new DomainException("Price can't be 0 or below.");

        if (weightInGrams < 0)
            throw new DomainException("Weight can't be below 0."); // Left possibility for zero in case that the employee didn't know the exact weight therefore left as 0

        return new Product(name, price, weightInGrams);
    }

    public void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName) || newName.Length > 255)
            throw new DomainException("Name can't be empty or exceed 255 characters.");

        Name = newName;
    }

    public void SetPrice(decimal newPrice)
    {
        if(newPrice <= 0)
            throw new DomainException("Price can't be 0 or below.");

        Price = newPrice;
    }

    public void SetWeight(int newWeight)
    {
        if (newWeight < 0)
            throw new DomainException("Weight can't be below 0.");

        WeightInGrams = newWeight;
    }
}
