using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens
{
    public abstract class Screen
    {
        protected Game _game;
        public Screen(Game game)
        {
            _game = game;
        }

        protected void ClearScreen()
        {
            Console.Clear();
        }
    }
}
