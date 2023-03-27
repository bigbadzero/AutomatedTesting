using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

public class IScreenFactory
{
    public static IScreen GetScreen(Enum action, IUserInput userInput, Survivor survivor)
    {
        IScreen screen = null;
        switch (action)
        {
            case ScreenActions.Equipment:
                return new EquipmentSubActionScreen(userInput, survivor);
            case EquipmentScreenActions.ViewEquipment:
                screen = new ViewEquipmentScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.ViewInHandEquipment:
                screen = new ViewInHandEquipmentScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.ViewReserveEquipment:
                screen = new ViewInReserveEquipmentScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.AddEquipment:
                screen = new AddEquipmentScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.DropEquipment:
                screen = new DropEquipmentScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToInHand:
                screen = new SetEquipmentToInHandScreen(userInput, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToReserve:
                screen = new SetEquipmentToReserveScreen(userInput, survivor);
                break;
            default:
                break;
        }

        return screen;
    }
}
