using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public class InHandEvent
{
    public Survivor Survivor;
    public Equipment EquipmentToBeInHand;
    public Game Game;

    public InHandEvent(Survivor survivor, Equipment equipmentToBeInHand, Game game)
    {
        Survivor = survivor;
        EquipmentToBeInHand = equipmentToBeInHand;
        Game = game;
    }
}