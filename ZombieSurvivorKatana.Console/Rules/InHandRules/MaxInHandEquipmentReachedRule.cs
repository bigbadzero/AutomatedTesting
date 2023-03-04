namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public class MaxInHandEquipmentReachedRule : IInHandRules
{
    public int Priority => 0;

    public void ExecuteRule(InHandEvent inHandEvent)
    {
        Console.Write("You already have the maximum amount of InHand Equipment.");
        Console.Write("Would you like to swap out an In Hand piece of Equipment");
        var swapOutEquipment = inHandEvent.Survivor._game._userInput.Proceed();
        if (swapOutEquipment == true)
        {
            var inHandEquipment = inHandEvent.Survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            Console.WriteLine("Which piece would you like to swap");
            for (int i = 0; i < inHandEquipment.Count; i++)
                Console.WriteLine($"{i + 1} {inHandEquipment[i].Name}");
            var indexOfEquipmentToBeSwapped = inHandEvent.Survivor._game._userInput.GetIntFromUserWithRange(1, inHandEquipment.Count);
            var inHandEquipmentToBeSwapped = inHandEquipment[indexOfEquipmentToBeSwapped - 1];
            var currentInHandEquipment = inHandEvent.Survivor.GetEqupment().Where(x => x.Id == inHandEquipmentToBeSwapped.Id).FirstOrDefault();
            inHandEvent.Survivor.SetEquipmentToReserve(currentInHandEquipment);
            inHandEvent.Survivor.SetEquipmentToInHand(inHandEvent.EquipmentToBeInHand);
            Console.WriteLine("Equipment Swapped");
        }
        else
            Console.WriteLine("Action Cancelled");
    }

    public bool IsRuleApplicable(InHandEvent inHandEvent)
    {
        var inHandEquipment = inHandEvent.Survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
        if (inHandEquipment.Count() < 2)
            return false;
        else
            return true;
    }
}
