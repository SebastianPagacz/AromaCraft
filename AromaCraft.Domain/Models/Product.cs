using System;

namespace AromaCraft.Domain.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int WieghtInGrams { get; private set; }

    private Product(string name, decimal price, int wieghtInGrams)
    {
        Name = name;
        Price = price;
        WieghtInGrams = wieghtInGrams;
    }
    private Product()
    {
        
    }

    public Product Create(string name, decimal price, int wieghtInGrams)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            throw new Exception(); // I need to create a domain exception for this business case

        if (price <= 0)
            throw new Exception();

        if (wieghtInGrams < 0)
            throw new Exception(); // Left possibility for zero in case that the employee didn't know the exact wieght therefore left as 0

        return new Product(name, price, wieghtInGrams);
    }

    public void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName) || newName.Length > 255)
            throw new Exception();

        Name = newName;
    }

    public void SetPrice(decimal newPrice)
    {
        if(newPrice <= 0)
            throw new Exception();

        Price = newPrice;
    }

    public void SetWeight(int newWeight)
    {
        if (newWeight < 0)
            throw new Exception();

        WieghtInGrams = newWeight;
    }
}
