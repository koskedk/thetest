using Microsoft.Extensions.Logging;
using Moq;
using TheTest.Controllers;
using TheTest.ServiceA;

namespace TheTest.Tests.Controllers;

[TestFixture]
public class WeatherForecastControllerTests
{
    private Mock<Application> _application;
    private WeatherForecastController _controller;
    
    [SetUp]
    public void Setup()
    {
        _application = new Mock<Application>();
        var logger = new Mock<ILogger<WeatherForecastController>>();
        _controller = new WeatherForecastController(logger.Object,_application.Object);
    }

    [Test]
    public void should_Select_Owner()
    {
        var res = _controller.Get();
        Assert.That(res.Any,Is.True);
    }
}