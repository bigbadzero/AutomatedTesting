﻿using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment.Actions;

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
            var printEquipmentAction = new ViewEquipmentAction();
            printEquipmentAction.PerformAction(addEquipmentEvent.Survivor);
            var indexOfEquipmentToBeDropped = addEquipmentEvent.Survivor._game._userInput.GetIntFromUserWithRange(1, addEquipmentEvent.Survivor.Equipment.Count);
            var inHandEquipmentToBeDropped = addEquipmentEvent.Survivor.Equipment[indexOfEquipmentToBeDropped - 1];
            addEquipmentEvent.Survivor.DropEquipment(inHandEquipmentToBeDropped);
            Console.WriteLine($"{addEquipmentEvent.Survivor.Name} dropped {inHandEquipmentToBeDropped.Name}");
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
