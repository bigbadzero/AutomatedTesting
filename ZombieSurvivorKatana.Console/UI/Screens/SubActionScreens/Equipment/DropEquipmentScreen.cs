using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class DropEquipmentScreen : SurvivorScreen, IScreen
{
    public DropEquipmentScreen(IUserInput userInput, Survivor survivor) : base(userInput, survivor) { }

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
            var viewEquipmentScreen = new ViewEquipmentScreen(_userInput, _survivor);
            viewEquipmentScreen.Execute();
            var indexOfEquipmentToDrop = _userInput.GetIntFromUserWithRange(1, _survivor.GetEqupment().Count);
            var equipmentToDrop = _survivor.GetEqupment()[indexOfEquipmentToDrop - 1];
            _survivor.DropEquipment(equipmentToDrop);
            _survivor.ActionsPerTurn--;
            Console.WriteLine($"{_survivor.Name} dropped {equipmentToDrop.Name}");
        }
        else
            Console.WriteLine($"{_survivor.Name} has no equipment to drop");
    }
}
