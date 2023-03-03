namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;

public class AddEquipmentMaxEquipmentReachedRule : IAddEquipmentRules
{
    public int Priority => 0;

    public void ExecuteRule(AddEquipmentEvent addEquipmentEvent)
    {
        Console.WriteLine("You already have the maximum amount of InHand Equipment.");
        Console.WriteLine("Would you like to swap out an In Hand piece of Equipment");
        var discardEquipment = addEquipmentEvent.Survivor._game._userInput.Proceed();
        if (discardEquipment == true)
        {
            var equipmentToDrop = addEquipmentEvent.Survivor.GetEquipmentToDrop();
            addEquipmentEvent.Survivor.DropEquipment(equipmentToDrop);
            Console.WriteLine($"{addEquipmentEvent.Survivor.Name} dropped {equipmentToDrop.Name}");
        }
        else
            Console.WriteLine($"{addEquipmentEvent.NewEquipment.Name} Discarded");
    }

    public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent)
    {
        if (addEquipmentEvent.Survivor.Equipment.Count == addEquipmentEvent.Survivor.MaxEquipment)
            return true;
        return false;
    }
}
