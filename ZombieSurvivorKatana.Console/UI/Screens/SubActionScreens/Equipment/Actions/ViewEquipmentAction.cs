using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class ViewEquipmentAction : IAction
    {
        public void PerformAction(Survivor survivor, Game game)
        {
            Console.WriteLine();
            if (survivor.GetEqupment().Count == 0)
                Console.WriteLine($"{survivor.Name} doesnt have any equipment");
            else
            {
                for (int i = 0; i < survivor.GetEqupment().Count; i++)
                    Console.WriteLine($"{i + 1} {survivor.GetEqupment()[i].Name}");
            }
            
        }
    }
}
