using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens
{
    public class GameStartScreen
    {
        private string StartMessage  = "Welcome to Zombie Survivor Game \nHow many surviviors will be in this game to begin with?";

        public void DisplayStartMessage()
        {
            Console.WriteLine(StartMessage);
        }

        public int GetNumberOfUsers(IUserInput userInput)
        {
            var numOfUsers = userInput.GetIntFromUser();
            return numOfUsers;
        }

        public string GetValidSurvivorName(IUserInput userInput, int survivorNum)
        {
            Console.WriteLine($"\nEnter the name for Survivior #{survivorNum}");
            var name = userInput.GetNameFromUser();
            return name;
        }

    }
}
