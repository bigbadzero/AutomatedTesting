namespace ZombieSurvivorKatana.ConsoleApp;

public class SuccessfulOperationEvent : Event
{
    public SuccessfulOperationEvent(string message)
    {
        EventDiscription = message;
    }
}
