using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorWoundedEvent : Event
{
    public SurvivorWoundedEvent(Survivor survivor)
    {
        EventDiscription = $"{survivor.Name} is wounded";
    }
}
