using TheTest.ServiceB;

namespace TheTest.ServiceA;

public class Application
{
    private readonly Data _data;
    
    public Application()
    {
        _data = new Data();
    }

    public string GetAppOwner()
    {
        return _data.SelectOwner();
    }
}