using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions
{
    public class DropEquipmentAction : SurvivorScreen, IScreen
    {
        public DropEquipmentAction(Game game, Survivor survivor) : base(game, survivor) { }

        public void DisplayScreenMessage()
        {
            Console.WriteLine("Which piece of equipment would you like to drop");
        }

        public void Execute()
        {
            ClearScreen();
            DisplayScreenMessage();
            if (_survivor.GetEqupment().Count > 0)
            {
                var viewEquipmentScreen = new ViewEquipmentScreen(_game, _survivor);
                viewEquipmentScreen.Execute();
                var indexOfEquipmentToDrop = _game._userInput.GetIntFromUserWithRange(1, _survivor.GetEqupment().Count);
                var equipmentToDrop = _survivor.GetEqupment()[indexOfEquipmentToDrop - 1];
                _survivor.DropEquipment(equipmentToDrop);
                Console.WriteLine($"{_survivor.Name} dropped {equipmentToDrop.Name}");
            }
            else
                Console.WriteLine($"{s  urvivor.Name} has no equipment to drop");
        }

        public Enum GetAction()
        {
            throw new NotImplementedException();
        }
    }
}
