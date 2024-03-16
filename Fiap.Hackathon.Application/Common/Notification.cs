namespace Fiap.Hackathon.Application.Common;

public class Notification(string key, string message)
{
    public string Key { get; } = key;
    public string Message { get; } = message;
}