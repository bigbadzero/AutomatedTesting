using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens
{
    public class GameActionScreen : SurvivorScreen, IScreen
    {
        public GameActionScreen(Game game, Survivor survivor) : base(game, survivor){}

        public void DisplayScreenMessage()
        {
            Console.WriteLine($"{_survivor.Name} has {_survivor.ActionsPerTurn} actions left\n");
            Console.WriteLine($"What Action Would {_survivor.Name} Like To Perform?");
        }

        public Enum GetAction()
        {
            var gameActions = Enum.GetNames(typeof(ScreenActions));
            for (int i = 0; i < gameActions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {gameActions[i]}");
            }
            var gameActionIndex = _game._userInput.GetIntFromUserWithRange(1, gameActions.Length);
            var gameAction = (ScreenActions)gameActionIndex;
            return gameAction;
        }

        public void Execute()
        {
            DisplayScreenMessage();
            var gameAction = GetAction();
            var survivorScreen = ISurvivorScreenFactory.GetSurvivorScreen(gameAction, _game, _survivor);
            survivorScreen.Execute();
        }

        

    }
}
