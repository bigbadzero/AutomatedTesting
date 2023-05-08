using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorCreatedEvent : Event
{
    public SurvivorCreatedEvent(Survivor survivor)
    {
        EventDiscription = $"{survivor.Name} was added to the game!";
    }
}
