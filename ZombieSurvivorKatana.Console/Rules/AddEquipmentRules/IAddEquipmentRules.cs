using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules
{
    public interface IAddEquipmentRules
    {
        int Priority { get; }
        public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent);

        public void ExecuteRule(AddEquipmentEvent addEquipmentEvent);
    }
}
