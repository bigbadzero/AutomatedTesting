using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment.Actions
{
    public class PrintEquipmentAction : IAction
    {
        public void PerformAction(Survivor survivor)
        {
            if (survivor.Equipment.Count == 0)
                Console.WriteLine($"{survivor.Name} doesnt have any equipment");
            else
            {
                for (int i = 0; i < survivor.Equipment.Count; i++)
                    Console.WriteLine($"{i + 1} {survivor.Equipment[i].Name}");
            }
            survivor.ActionsPerTurn--;
            
        }
    }
}
