namespace TheTest.ServiceA.Tests;

public class ApplicationTests
{
    private Application _application;
    [SetUp]
    public void Setup()
    {
        _application = new Application();
    }

    [Test]
    public void should_GetAppOwner()
    {
        var res = _application.GetAppOwner();
        Assert.That(res,Is.Not.Empty);
    }
}