using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules
{
    public class AddEquipmentMaxEquipmentNotReachedRule : IAddEquipmentRules
    {
        public int Priority => 1;

        public void ExecuteRule(AddEquipmentEvent addEquipmentEvent)
        {
            addEquipmentEvent.Survivor.Equipment.Add(addEquipmentEvent.NewEquipment);
        }

        public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent)
        {
            if (addEquipmentEvent.Survivor.Equipment.Count < addEquipmentEvent.Survivor.MaxEquipment)
                return true;
            return false;
        }
    }
}
