using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;

public class AddEquipmentMaxEquipmentReachedRule : IAddEquipmentRules
{
    public int Priority => 0;

    public void ExecuteRule(AddEquipmentEvent addEquipmentEvent)
    {
        Console.WriteLine("You already have the maximum amount of InHand Equipment.");
        Console.WriteLine("Would you like to swap out an In Hand piece of Equipment");
        var discardEquipment = addEquipmentEvent.Game._userInput.Proceed();
        if (discardEquipment == true)
        {
            var printEquipmentAction = new ViewEquipmentAction();
            printEquipmentAction.PerformAction(addEquipmentEvent.Survivor, addEquipmentEvent.Game);
            var indexOfEquipmentToBeDropped = addEquipmentEvent.Game._userInput.GetIntFromUserWithRange(1, addEquipmentEvent.Survivor.GetEqupment().Count);
            var inHandEquipmentToBeDropped = addEquipmentEvent.Survivor.GetEqupment()[indexOfEquipmentToBeDropped - 1];
            addEquipmentEvent.Survivor.DropEquipment(inHandEquipmentToBeDropped);
            Console.WriteLine($"{addEquipmentEvent.Survivor.Name} dropped {inHandEquipmentToBeDropped.Name}");
        }
        else
            Console.WriteLine($"{addEquipmentEvent.NewEquipment.Name} Discarded");
    }

    public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent)
    {
        if (addEquipmentEvent.Survivor.GetEqupment().Count == addEquipmentEvent.Survivor.MaxEquipment)
            return true;
        return false;
    }
}
