using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class SetCurrentEquipmentToInHandAction : IAction
    {
        private List<IInHandRules> InHandRules = new List<IInHandRules>()
        {
            new MaxInHandEquipmentNotReachedRule(),
            new MaxInHandEquipmentReachedRule()
        };

        public void PerformAction(Survivor survivor)
        {
            if(survivor.GetEqupment().Count > 0 && survivor.GetEqupment().Any(x => x.EquipmentType == EquipmentTypeEnum.Reserve))
            {
                var equipmentNotInhand = survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.Reserve).ToList();
                for (int i = 0; i < equipmentNotInhand.Count; i++)
                    Console.WriteLine($"{i + 1} {equipmentNotInhand[i].Name}");
                var indexOfEquipmentToBeInHand = survivor._game._userInput.GetIntFromUserWithRange(1, equipmentNotInhand.Count);
                var equipment = survivor.GetEqupment()[indexOfEquipmentToBeInHand - 1];
                var inHandEvent = new InHandEvent(survivor, equipment);
                foreach (var rule in InHandRules.OrderBy(x => x.Priority))
                {
                    if (rule.IsRuleApplicable(inHandEvent))
                        rule.ExecuteRule(inHandEvent);
                }
            }
            else
            {
                Console.WriteLine($"{survivor.Name} doesnt have any equipment that can be set to InHand");
            }
        }
    }
}
