using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Actions;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens
{
    public class GameActionScreen
    {
        public GameActions GetAction(IUserInput userInput, Survivor survivor)
        {
            Console.WriteLine($"What Action Would {survivor.Name} Like To Perform?");
            var gameActions = Enum.GetNames(typeof(GameActions));
            for (int i = 0; i < gameActions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {gameActions[i]}");
            }
            var gameActionIndex= userInput.GetIntFromUserWithRange(1, gameActions.Length);
            var gameAction = (GameActions)gameActionIndex;
            return gameAction;
        }

    }
}
