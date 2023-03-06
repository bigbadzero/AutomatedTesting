using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens
{
    public class ViewEquipmentScreen : SurvivorScreen, IScreen
    {
        public ViewEquipmentScreen(Game game, Survivor survivor) : base(game, survivor){}

        public void DisplayScreenMessage()
        {
            if (_survivor.GetEqupment().Count == 0)
                Console.WriteLine($"{_survivor.Name} doesnt have any equipment");
            else
            {
                for (int i = 0; i < _survivor.GetEqupment().Count; i++)
                    Console.WriteLine($"{i + 1} {_survivor.GetEqupment()[i].Name}");
            }
        }

        public void Execute()
        {
            ClearScreen();
            DisplayScreenMessage();
        }

        public Enum GetAction()
        {
            throw new NotImplementedException();
        }
    }
}
