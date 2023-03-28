using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class ViewEquipmentScreen : SurvivorScreen, IScreen
{
    public ViewEquipmentScreen(Game game, Survivor survivor) : base(game, survivor) { }

    public void DisplayScreenMessage()
    {
        if (_survivor.Equipment.Count == 0)
            Console.WriteLine($"{_survivor.Name} doesnt have any equipment");
        else
        {
            for (int i = 0; i < _survivor.Equipment.Count; i++)
                Console.WriteLine($"{i + 1} {_survivor.Equipment[i].Name}");
        }
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
    }
}
