using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;

public class AddEquipmentEvent
{
    public Survivor Survivor;
    public Equipment NewEquipment;
    public Game Game;

    public AddEquipmentEvent(Survivor survivor, Equipment newEquipment, Game game)
    {
        Survivor = survivor;
        NewEquipment = newEquipment;
        Game = game;
    }
}
