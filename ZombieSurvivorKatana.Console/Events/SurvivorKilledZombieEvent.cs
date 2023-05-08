using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorKilledZombieEvent : Event
{
    public SurvivorKilledZombieEvent(Survivor survivor)
    {
        EventDiscription = $"{survivor.Name} killed the zombie";
    }
}
