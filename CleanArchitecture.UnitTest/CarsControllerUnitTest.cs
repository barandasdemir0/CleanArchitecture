using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async Task Create_ReturnOkResult_WhenRequestIsValid()
    {
        //Arrange
        var mediatorMock =  new Mock<IMediator>();
        CreateCarCommand createCarCommand = new(
            "Toyota","Corolla",5000);

        MessageResponse messageResponse = new("Araç Başarıyla Kaydedildi");
        CancellationToken cancellationToken = new();


        mediatorMock.Setup(m=> m.Send(createCarCommand,cancellationToken)).ReturnsAsync(messageResponse);


        CarsController carsController = new(mediatorMock.Object);

        //act

        var result = await carsController.CreateCar(createCarCommand, cancellationToken);

        //assert

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(messageResponse, returnValue);
        

        mediatorMock.Verify(m=>m.Send(createCarCommand,cancellationToken), Times.Once);
    }
}
