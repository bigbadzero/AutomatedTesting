using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class AddEquipmentAction : IAction
    {
        private List<IAddEquipmentRules> AddEquipmentRules = new List<IAddEquipmentRules>()
        {
             new AddEquipmentMaxEquipmentNotReachedRule(),
            new AddEquipmentMaxEquipmentReachedRule()
        };

        public void PerformAction(Survivor survivor)
        {
            Console.WriteLine("\nEnter the name of the new piece of equipment you have found.");
            var newEquipmentName = survivor._game._userInput.GetNameFromUser();
            var test = new Equipment("test");
            var newEquipment = new Equipment(newEquipmentName);
            var addEquipmentEvent = new AddEquipmentEvent(survivor, newEquipment);
            foreach (var rule in AddEquipmentRules.OrderBy(x => x.Priority))
            {
                if (rule.IsRuleApplicable(addEquipmentEvent))
                    rule.ExecuteRule(addEquipmentEvent);
            }
        }
    }
}
