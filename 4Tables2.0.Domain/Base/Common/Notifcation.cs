namespace _4Tables2._0.Domain.Base.Common;

public class Notifcation
{
    private Notifcation(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }

    protected Notifcation() { }

    public string PropertyName { get; }
    public string Message { get; }

    public static Notifcation Create(string propertyName, string message)
    {
        return
            new Notifcation(propertyName, message);
    }
}
