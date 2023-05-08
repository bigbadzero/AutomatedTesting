using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorLevelUpEvent : Event
{
    public SurvivorLevelUpEvent(Survivor survivor)
    {
        EventDiscription = $"{survivor.Name} has leveled up to {survivor.Level}";
    }
}
