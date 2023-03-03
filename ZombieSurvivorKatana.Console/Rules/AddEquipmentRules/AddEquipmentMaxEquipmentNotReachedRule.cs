namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;

public class AddEquipmentMaxEquipmentNotReachedRule : IAddEquipmentRules
{
    public int Priority => 1;

    public void ExecuteRule(AddEquipmentEvent addEquipmentEvent)
    {
        addEquipmentEvent.Survivor.AddEquipment(addEquipmentEvent.NewEquipment);
        addEquipmentEvent.Survivor.ActionsPerTurn--;
        Console.WriteLine($"{addEquipmentEvent.Survivor.Name} added {addEquipmentEvent.NewEquipment.Name} to equipment inventory");
    }

    public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent)
    {
        if (addEquipmentEvent.Survivor.Equipment.Count < addEquipmentEvent.Survivor.MaxEquipment)
            return true;
        return false;
    }
}
