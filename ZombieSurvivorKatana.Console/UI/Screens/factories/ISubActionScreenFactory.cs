using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

public class ISubActionScreenFactory
{
    public static IScreen GetSubScreen(Enum action, Game game, Survivor survivor)
    {
        IScreen iScreen = null;
        switch (action)
        {
            case EquipmentScreenActions.ViewEquipment:
                iScreen = new ViewEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.ViewInHandEquipment:
                iScreen = new ViewInHandEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.ViewReserveEquipment:
                iScreen = new ViewInReserveEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.AddEquipment:
                iScreen = new AddEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.DropEquipment:
                iScreen = new DropEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToInHand:
                iScreen = new SetEquipmentToInHandScreen(game, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToReserve:
                iScreen = new SetEquipmentToReserveScreen(game, survivor);
                break;
            default:
                break;
        }


        return iScreen;
    }
}
