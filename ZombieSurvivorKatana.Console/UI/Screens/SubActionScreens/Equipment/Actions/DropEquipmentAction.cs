using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class DropEquipmentAction : IAction
    {
        public void PerformAction(Survivor survivor, Game game)
        {
            if(survivor.GetEqupment().Count> 0)
            {
                var printEquipmentAction = new ViewEquipmentAction();
                printEquipmentAction.PerformAction(survivor, game);
                var indexOfEquipmentToDrop = game._userInput.GetIntFromUserWithRange(1, survivor.GetEqupment().Count);
                var equipmentToDrop = survivor.GetEqupment()[indexOfEquipmentToDrop - 1];
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
