using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules
{
    public class AddEquipmentMaxEquipmentReachedRule : IAddEquipmentRules
    {
        public int Priority =>0;

        public void ExecuteRule(AddEquipmentEvent addEquipmentEvent)
        {
            Console.WriteLine(Constants.GetMaxEquipmentMessage());
            var discardEquipment = addEquipmentEvent.Survivor._userInput.Proceed();
            if (discardEquipment == true)
            {
                var equipmentToDrop = addEquipmentEvent.Survivor.GetEquipmentToDrop();
                addEquipmentEvent.Survivor.DropEquipment(equipmentToDrop);
            }

            else
            {
                Console.WriteLine($"{addEquipmentEvent.NewEquipment.Name} Discarded");
            }
        }

        public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent)
        {
            if(addEquipmentEvent.Survivor.Equipment.Count == addEquipmentEvent.Survivor.MaxEquipment)
                    return true;
            return false;
        }
    }
}
