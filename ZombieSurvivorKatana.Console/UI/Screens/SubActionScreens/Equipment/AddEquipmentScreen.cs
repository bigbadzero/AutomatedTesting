using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class AddEquipmentScreen : SurvivorScreen, IScreen
{

    public AddEquipmentScreen(Game game, Survivor survivor) : base(game, survivor) { }

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
        _survivor.AddEquipment(newEquipment);
    }
}
