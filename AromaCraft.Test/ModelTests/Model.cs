using System;
using AromaCraft.Domain.Exceptions;
using AromaCraft.Domain.Models;
using Xunit;

namespace AromaCraft.Domain.UnitTests.ModelTests;

public class Model
{
    // Model creation tests

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
    
    // Model manipulation tests
    [Fact]
    public void ChangeMethods_Returns_CorrectValue()
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        string name = "Czarna kawa";
        decimal price = 20.99m;
        int weight = 100;
        // Act
        product.SetName(name);
        product.SetPrice(price);
        product.SetWeight(weight);
        // Assert
        Assert.Multiple(
            () => Assert.Equal(name, product.Name),
            () => Assert.Equal(price, product.Price),
            () => Assert.Equal(weight, product.WeightInGrams)
        );
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void SetName_Returns_CorrectValue(string name)
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        // Act
        var action = () => product.SetName(name);
        // Assert
        var exception = Assert.Throws<DomainException>(action);
        Assert.Equal("Name can't be empty or exceed 255 characters.", exception.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-14.99)]
    public void SetPrice_Returns_CorrectValue(decimal price)
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        // Act
        var action = () => product.SetPrice(price);
        // Assert
        var exception = Assert.Throws<DomainException>(action);
        Assert.Equal("Price can't be 0 or below.", exception.Message);
    }

    [Fact]
    public void SetWeight_Returns_CorrectVale()
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        // Act
        var action = () => product.SetWeight(-100);
        // Assert
        var exception = Assert.Throws<DomainException>(action);
        Assert.Equal("Weight can't be below 0.", exception.Message);
    }
}
