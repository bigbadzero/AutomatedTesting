using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.CreateCharacter;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

public class IScreenFactory
{
    public static IScreen GetScreen(Enum action, Game game, Survivor survivor)
    {
        IScreen screen = null;
        switch (action)
        {
            case ScreenActions.CreateCharacter:
                return new CreateSurvivorScreen(game, survivor);
            case ScreenActions.Equipment:
                return new EquipmentSubActionScreen(game, survivor);
            case ScreenActions.AttackZombie:
                return new AttackZombieScreen(game, survivor);
            case EquipmentScreenActions.ViewEquipment:
                screen = new ViewEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.ViewInHandEquipment:
                screen = new ViewInHandEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.ViewReserveEquipment:
                screen = new ViewInReserveEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.AddEquipment:
                screen = new AddEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.DropEquipment:
                screen = new DropEquipmentScreen(game, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToInHand:
                screen = new SetEquipmentToInHandScreen(game, survivor);
                break;
            case EquipmentScreenActions.SetEquipmentToReserve:
                screen = new SetEquipmentToReserveScreen(game, survivor);
                break;
            default:
                break;
        }

        return screen;
    }
}
