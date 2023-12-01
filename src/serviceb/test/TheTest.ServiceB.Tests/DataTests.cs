namespace TheTest.ServiceB.Tests;

public class DataTests
{
    private Data _data;
    [SetUp]
    public void Setup()
    {
        _data = new Data();
    }

    [Test]
    public void should_Select_Owner()
    {
        var res = _data.SelectOwner();
        Assert.That(res,Is.Not.Empty);
    }
}