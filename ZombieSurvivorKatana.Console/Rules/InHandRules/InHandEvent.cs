using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public class InHandEvent
{
    public Survivor Survivor;
    public Equipment EquipmentToBeInHand;

    public InHandEvent(Survivor survivor, Equipment equipmentToBeInHand)
    {
        Survivor = survivor;
        EquipmentToBeInHand= equipmentToBeInHand;
    }
}