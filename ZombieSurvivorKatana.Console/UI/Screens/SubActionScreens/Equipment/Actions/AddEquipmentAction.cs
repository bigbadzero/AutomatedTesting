using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class AddEquipmentAction : SurvivorScreen, IScreen
    {

        public AddEquipmentAction(Game game, Survivor survivor) : base(game, survivor)
        {
        }

        public void DisplayScreenMessage()
        {
            Console.WriteLine("Enter the name of the new piece of equipment you have found.");
        }

        public void Execute()
        {
            ClearScreen();
            DisplayScreenMessage();
            var newEquipmentName = _game._userInput.GetNameFromUser();
            var newEquipment = new Equipment(newEquipmentName);
            if (_survivor.GetEqupment().Count < _survivor.MaxEquipment)
            {
                _survivor.AddEquipment(newEquipment);
                _survivor.ActionsPerTurn--;
                Console.WriteLine($"{_survivor.Name} added {newEquipment.Name} to Equipment List");
            }
            else
                Console.WriteLine("Equipment is full");
        }

        public Enum GetAction()
        {
            throw new NotImplementedException();
        }
    }
}
