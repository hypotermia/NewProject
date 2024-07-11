using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MiniProjects.Interfaces;
using MiniProjects.MediaTR;
using MiniProjects.Models;
using MiniProjects.Repository;
using MiniProjects.Validators;
using Moq;
using Xunit;

public class AddProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepository;
    private readonly IValidator<Product> _validator;
    private readonly AddProductCommandHandler _handler;

    public AddProductCommandHandlerTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _validator = new ProductValidator();
        _handler = new AddProductCommandHandler(_mockRepository.Object, _validator);
    }

    [Fact]
    public async Task Handle_ValidCommand_AddsProduct()
    {
        var command = new AddProductCommand
        {
            ProductsName = "Test Product",
            ProductsPrices = 10.0m,
            Quantity = 5
        };

        await _handler.Handle(command, CancellationToken.None);

        _mockRepository.Verify(r => r.AddTaskAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ThrowsValidationException()
    {
        var command = new AddProductCommand
        {
            ProductsName = "",
            ProductsPrices = -1.0m,
            Quantity = -5
        };

        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
