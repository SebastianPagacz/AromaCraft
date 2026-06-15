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
        Assert.Equal(mockProduct.Value.Name, result.Value.Name); 
    }

    [Fact]
    public void CreateProduct_NameTooLong_Returns_CorrectValue()
    {
        // Arrange & Act
        string name = new string('a', 256);
        var result = Product.Create(name, 12.50m, 500);
        // Assert
        Assert.Equal("Name can't be empty or exceed 255 characters.", result.Message);
    }

    [Theory]
    [InlineData("", 12, 1000)]
    [InlineData(" ", 12, 1000)]
    public void CreateProduct_Returns_NameDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = Product.Create(name, price, weightInGrams);
        // Assert
        Assert.Equal("Name can't be empty or exceed 255 characters.", result.Message);
    }

    [Theory]
    [InlineData("Kawa", -1, 1000)]
    [InlineData("Kawa", 0, 1000)]
    public void CreateProduct_Returns_PriceDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = Product.Create(name, price, weightInGrams);
        // Assert
        Assert.Equal("Price can't be 0 or below.", result.Message);
    }

    [Theory]
    [InlineData("Kawa", 10, -10)]
    public void CreateProduct_Returns_weightDomainException(string name, decimal price, int weightInGrams)
    {
        // Arrange & Act
        var result = Product.Create(name, price, weightInGrams);
        // Assert
        Assert.Equal("Weight can't be negative.", result.Message);
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
        product.Value.SetName(name);
        product.Value.SetPrice(price);
        product.Value.SetWeight(weight);
        // Assert
        Assert.Multiple(
            () => Assert.Equal(name, product.Value.Name),
            () => Assert.Equal(price, product.Value.Price),
            () => Assert.Equal(weight, product.Value.WeightInGrams)
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
        var result = product.Value.SetName(name);
        // Assert
        Assert.Equal("Name can't be empty or exceed 255 characters.", result.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-14.99)]
    public void SetPrice_Returns_CorrectValue(decimal price)
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        // Act
        var result = product.Value.SetPrice(price);
        // Assert
        Assert.Equal("Price can't be 0 or below.", result.Message);
    }

    [Fact]
    public void SetWeight_Returns_CorrectVale()
    {
        // Arrange
        var product = Product.Create("kawa", 19.99m, 1000);
        // Act
        var result = product.Value.SetWeight(-100);
        // Assert
        Assert.Equal("Weight can't be negative.", result.Message);
    }
}
