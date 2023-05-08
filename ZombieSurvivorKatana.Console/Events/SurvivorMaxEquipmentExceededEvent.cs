using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorMaxEquipmentExceededEvent : Event
{
    public SurvivorMaxEquipmentExceededEvent(Survivor survivor, Equipment equipment)
    {
        EventDiscription = $"Due to wounds {survivor.Name} has dropped their {equipment.Name}";
    }
}
