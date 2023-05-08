using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorDeathEvent : Event
{
    public SurvivorDeathEvent(Survivor survivor)
    {
        EventDiscription = $"{survivor.Name} has died tragically due to their wounds.";
    }
}
