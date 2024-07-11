using FluentValidation.TestHelper;
using MiniProjects.Models;
using MiniProjects.Validators;
using Xunit;

public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    [Fact]
    public void Should_Have_Error_When_ProductsName_Is_Empty()
    {
        var product = new Product { ProductsName = "" };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.ProductsName);
    }

    [Fact]
    public void Should_Have_Error_When_ProductsPrices_Is_Negative()
    {
        var product = new Product { ProductsPrices = -1 };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.ProductsPrices);
    }

    [Fact]
    public void Should_Have_Error_When_Quantity_Is_Negative()
    {
        var product = new Product { Quantity = -1 };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Quantity);
    }

    [Fact]
    public void Should_Not_Have_Error_When_ProductsName_Is_Specified()
    {
        var product = new Product { ProductsName = "Test Product" };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.ProductsName);
    }

    [Fact]
    public void Should_Not_Have_Error_When_ProductsPrices_Is_Positive()
    {
        var product = new Product { ProductsPrices = 10.0m };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.ProductsPrices);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Quantity_Is_Zero_Or_More()
    {
        var product = new Product { Quantity = 0 };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Quantity);
    }
}
