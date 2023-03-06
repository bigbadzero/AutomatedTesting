using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens
{
    public class GameStartScreen: Screen, IScreen
    {
        private string StartMessage  = "Welcome to Zombie Survivor Game \nHow many surviviors will be in this game to begin with?";

        public GameStartScreen(Game game) : base(game)
        {
        }

        public void DisplayScreenMessage()
        {
            Console.WriteLine(StartMessage);
        }

        public Enum GetAction()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            ClearScreen();
            DisplayScreenMessage();
            var numOfUsers = _game._userInput.GetIntFromUser();
            CreateSurvivors(numOfUsers);
        }

        private string GetValidSurvivorName(int survivorNum)
        {
            Console.WriteLine($"\nEnter the name for Survivior #{survivorNum}");
            var name = _game._userInput.GetNameFromUser();
            return name;
        }


        public void CreateSurvivors(int numOfSurvivors)
        {
            for (int i = 0; i < numOfSurvivors; i++)
            {
                var created = false;
                while (!created)
                {
                    var name = GetValidSurvivorName(i + 1);
                    var surviviorAlreadyExist = _game.SurvivorAlreadyExists(name);
                    if (surviviorAlreadyExist)
                        Console.WriteLine($"Survivor with the name {name} already exists");
                    else
                    {
                        _game.CreateSurvivor(name);
                        created = true;
                    }
                }
            }
        }
    }
}
