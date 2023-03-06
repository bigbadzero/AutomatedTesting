using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class ViewInReserveEquipmentScreen : SurvivorScreen, IScreen
{
    public ViewInReserveEquipmentScreen(Game game, Survivor survivor) : base(game, survivor) { }

    public void DisplayScreenMessage()
    {
        var inReserveEquipment = _survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.Reserve);
        if (inReserveEquipment.Count() == 0)
            Console.WriteLine($"{_survivor.Name} doesnt have any equipment in reserve");
        else
            for (int i = 0; i < inReserveEquipment.Count(); i++)
                Console.WriteLine($"{i + 1} {_survivor.GetEqupment()[i].Name}");
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
    }

    public Enum GetAction()
    {
        throw new NotImplementedException();
    }
}
