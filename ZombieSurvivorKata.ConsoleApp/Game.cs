using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKata.ConsoleApp
{
    public static class Game
    {
        public static List<Survivor> _survivors = new List<Survivor>();
        public static IUserInput _userInput;

        public static void Configure(IUserInput userInput)
        {
            _userInput= userInput;
        }

        public static void CreateCharacter(string characterName)
        {
            var doesNameExists = _survivors.Any(x => x._name == characterName);
            if (doesNameExists)
                Console.WriteLine("Character with that name already exists");
            else
            {
                var newSurvivor = new Survivor(characterName, _userInput);
                _survivors.Add(newSurvivor);
            }
        }

        public static void AnySurvivorsLeft()
        {
            var anySurvivorsLeft = _survivors.Any(x => x._alive ==true);
            if (!anySurvivorsLeft)
                GameOver();
        }

        public static void GameOver()
        {
            Console.WriteLine("Game Over");
            Environment.Exit(0);
        }
    }
}
