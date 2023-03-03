namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public class MaxInHandEquipmentReachedRule : IInHandRules
{
    public int Priority => 0;

    public void ExecuteRule(InHandEvent inHandEvent)
    {
        var inHandEquipment = inHandEvent.Survivor.Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
        Console.Write("You already have the maximum amount of InHand Equipment.");
        Console.Write("Would you like to swap out an In Hand piece of Equipment");
        var swapOutEquipment = inHandEvent.UserInput.Proceed();
        if (swapOutEquipment == true)
        {
            Console.WriteLine("Which piece would you like to swap");
            inHandEvent.Survivor.PrintEquipment(inHandEquipment);
            var indexOfEquipmentToBeSwapped = inHandEvent.UserInput.GetIntFromUserWithRange(0, 1);
            var inHandequipmentToBeSwapped = inHandEquipment[indexOfEquipmentToBeSwapped];
            var currentInHandEquipment = inHandEvent.Survivor.Equipment.Where(x => x.Id == inHandequipmentToBeSwapped.Id).FirstOrDefault();
            currentInHandEquipment.EquipmentType = EquipmentTypeEnum.Reserve;
            inHandEvent.Survivor.Equipment[inHandEvent.IndexOfEquipmentToBeInHand].EquipmentType = EquipmentTypeEnum.InHand;
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
