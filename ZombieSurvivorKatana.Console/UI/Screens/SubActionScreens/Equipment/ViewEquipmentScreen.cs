using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class ViewEquipmentScreen : SurvivorScreen, IScreen
{
    public ViewEquipmentScreen(IUserInput userInput, Survivor survivor) : base(userInput, survivor) { }

    public void DisplayScreenMessage()
    {
        if (_survivor.GetEqupment().Count == 0)
            Console.WriteLine($"{_survivor.Name} doesnt have any equipment");
        else
        {
            for (int i = 0; i < _survivor.GetEqupment().Count; i++)
                Console.WriteLine($"{i + 1} {_survivor.GetEqupment()[i].Name}");
        }
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
    }
}
