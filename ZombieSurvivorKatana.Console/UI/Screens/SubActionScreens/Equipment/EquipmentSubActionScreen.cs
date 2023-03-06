using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class EquipmentSubActionScreen : SurvivorScreen, IScreen
{
    public EquipmentSubActionScreen(Game game, Survivor survivor) : base(game, survivor) { }

    public void DisplayScreenMessage()
    {
        Console.WriteLine($"What Equipment Action Would {_survivor.Name} Like To Perform?");
    }

    public Enum GetAction()
    {
        var equipmentActions = Enum.GetNames(typeof(EquipmentScreenActions));
        for (int i = 0; i < equipmentActions.Length; i++)
        {
            Console.WriteLine($"{i + 1} {equipmentActions[i]}");
        }
        var modifyEquipmentActionIndex = _game._userInput.GetIntFromUserWithRange(1, equipmentActions.Length);
        var gameAction = (EquipmentScreenActions)modifyEquipmentActionIndex;
        return gameAction;
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
        var action = GetAction();
        var equipmentActionScreen = IScreenFactory.GetScreen(action, _game, _survivor);
        equipmentActionScreen.Execute();
    }
}
