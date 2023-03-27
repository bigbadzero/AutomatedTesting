using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class EquipmentSubActionScreen : SurvivorScreen, IScreen
{
    public EquipmentSubActionScreen(IUserInput userInput, Survivor survivor) : base(userInput, survivor) { }
    private EquipmentScreenActions action { get; set; }

    public void DisplayScreenMessage()
    {
        Console.WriteLine($"What Equipment Action Would {_survivor.Name} Like To Perform?");
        var equipmentActions = Enum.GetNames(typeof(EquipmentScreenActions));
        for (int i = 0; i < equipmentActions.Length; i++)
        {
            Console.WriteLine($"{i + 1} {equipmentActions[i]}");
        }
        var modifyEquipmentActionIndex = _userInput.GetIntFromUserWithRange(1, equipmentActions.Length);
        action = (EquipmentScreenActions)modifyEquipmentActionIndex;
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
        var equipmentActionScreen = IScreenFactory.GetScreen(action, _userInput, _survivor);
        equipmentActionScreen.Execute();
    }
}
