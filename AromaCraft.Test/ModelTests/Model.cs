using System;
using AromaCraft.Domain.Models;
using Xunit;

namespace AromaCraft.Domain.UnitTests.ModelTests;

public class Model
{
    [Fact]
    public void CreateProduct_Returns_CorrectValue()
    {
        // Arrange & Act
        var result = Product.Create("Kawa", 12, 1000);
        // Assert
        Assert.Equal(Product.Create("Kawa", 12, 1000), result);
    }
}
