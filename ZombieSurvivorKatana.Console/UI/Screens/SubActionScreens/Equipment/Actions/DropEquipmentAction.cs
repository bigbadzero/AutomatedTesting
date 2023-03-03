using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment.Actions
{
    public class DropEquipmentAction : IAction
    {
        public void PerformAction(Survivor survivor)
        {
            if(survivor.Equipment.Count> 0)
            {
                var printEquipmentAction = new PrintEquipmentAction();
                printEquipmentAction.PerformAction(survivor);
                var indexOfEquipmentToDrop = survivor._game._userInput.GetIntFromUserWithRange(1, survivor.Equipment.Count);
                var equipmentToDrop = survivor.Equipment[indexOfEquipmentToDrop - 1];
                survivor.DropEquipment(equipmentToDrop);
                Console.WriteLine($"{survivor.Name} dropped {equipmentToDrop.Name}");
            }
            else
            {
                Console.WriteLine($"{survivor.Name} has no equipment to drop");
            }
        }
    }
}
