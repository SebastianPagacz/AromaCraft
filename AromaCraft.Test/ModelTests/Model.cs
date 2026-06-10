using System;
using AromaCraft.Domain.Exceptions;
using AromaCraft.Domain.Models;
using Xunit;

namespace AromaCraft.Domain.UnitTests.ModelTests;

public class Model
{
    [Fact]
    public void CreateProduct_Returns_CorrectValue()
    {
        // Arrange & Act
        var result = Product.Create("Kawa", 12.00m, 1000);
        var mockProduct = Product.Create("Kawa", 12.00m, 1000);
        // Assert
        Assert.Equal(mockProduct.Name, result.Name); 
    }

    [Fact]
    public void CreateProduct_NameTooLong_Returns_CorrectValue()
    {
        // Arrange & Act
        string name = new string('a', 256);
        var result = () => Product.Create(name, 12.50m, 500);
        // Assert
        var exception = Assert.Throws<DomainException>(result);
        Assert.Equal("Name can't be empty or exceed 255 characters.", exception.Message);
    }

    [Theory]
    [InlineData("", 12, 1000)]
    [InlineData(" ", 12, 1000)]
    public void CreateProduct_Returns_NameDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = () => Product.Create(name, price, weightInGrams); // I don't understand why making this a annonymus function makes it work
        // Assert
        var exception = Assert.Throws<DomainException>(result);
        Assert.Equal("Name can't be empty or exceed 255 characters.", exception.Message);
    }

    [Theory]
    [InlineData("Kawa", -1, 1000)]
    [InlineData("Kawa", 0, 1000)]
    public void CreateProduct_Returns_PriceDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = () => Product.Create(name, price, weightInGrams);
        // Assert
        var exception = Assert.Throws<DomainException>(result);
        Assert.Equal("Price can't be 0 or below.", exception.Message);
    }

    [Theory]
    [InlineData("Kawa", 10, -10)]
    public void CreateProduct_Returns_weightDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = () => Product.Create(name, price, weightInGrams);
        // Assert
        var exception = Assert.Throws<DomainException>(result);
        Assert.Equal("Weight can't be below 0.", exception.Message);
    }
}
