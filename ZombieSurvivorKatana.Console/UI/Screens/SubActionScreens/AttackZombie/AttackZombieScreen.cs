using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens
{
    public class AttackZombieScreen : SurvivorScreen, IScreen
    {
        public AttackZombieScreen(Game game, Survivor survivor) : base(game, survivor)
        {
        }

        public void DisplayScreenMessage()
        {
            ClearScreen();
            Console.WriteLine($"{_survivor.Name} kills a zombie!!");
        }

        public void Execute()
        {
            DisplayScreenMessage();
            _survivor.Attack();
        }
    }
}
