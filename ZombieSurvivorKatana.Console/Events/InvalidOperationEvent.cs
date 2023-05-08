namespace ZombieSurvivorKatana.ConsoleApp;

public class InvalidOperationEvent : Event
{
    public InvalidOperationEvent(string message)
    {
        EventDiscription = $"Invalid operation {message}";
    }
}
