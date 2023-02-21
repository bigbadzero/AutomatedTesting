using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules
{
    public class MaxInHandEquipmentReachedRule : IRules
    {

        public void ExecuteRule(InHandEvent inHandEvent)
        {
            var inHandEquipment = inHandEvent.Survivor.Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            Console.Write(Constants.GetMaxInHandEquipmentMessage());
            var swapOutEquipment = inHandEvent.UserInput.Proceed();
            if (swapOutEquipment == true)
            {
                //if they do get the piece to no longer be inHand and and new piece to Inhand
                Console.WriteLine("Which piece would you like to swap");
                inHandEvent.Survivor.PrintCurrentInHandEquipment();
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
}
