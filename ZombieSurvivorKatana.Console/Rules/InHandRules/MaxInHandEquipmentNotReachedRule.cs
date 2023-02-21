using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules
{
    public class MaxInHandEquipmentNotReachedRule : IInHandRules
    {
        public int Priority => 0;
        public void ExecuteRule(InHandEvent inHandEvent)
        {
            inHandEvent.Survivor.Equipment[inHandEvent.IndexOfEquipmentToBeInHand].EquipmentType = EquipmentTypeEnum.InHand;
        }

        public bool IsRuleApplicable(InHandEvent inHandEvent)
        {
            var inHandEquipment = inHandEvent.Survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            if (inHandEquipment.Count() < 2)
                return true;
            else 
                return false;
        }
    }
}
