using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment.Actions
{
    public class ViewInHandEquipmentAction : IAction
    {
        public void PerformAction(Survivor survivor)
        {
            var inHandEquipment = survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand);
            if(inHandEquipment.Count() == 0)
                Console.WriteLine($"{survivor.Name} doesnt have any equipment in hand");
            else
            {
                for (int i = 0; i < inHandEquipment.Count(); i++)
                    Console.WriteLine($"{i + 1} {survivor.GetEqupment()[i].Name}");
            }
        }
    }
}
