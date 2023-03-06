using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Actions;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

public class IActionFactory
{
    public static IAction GetIAction(Enum action)
    {
        IAction iAction = null;
        switch (action)
        {
            case EquipmentScreenActions.PrintEquipment:
                iAction = new ViewEquipmentAction();
                break;
            case EquipmentScreenActions.PrintInHandEquipment:
                iAction = new ViewInHandEquipmentAction();
                break;
            case EquipmentScreenActions.AddEquipment:
                iAction = new AddEquipmentAction();
                break;
            case EquipmentScreenActions.DropEquipment:
                iAction = new DropEquipmentAction();
                break;
            case EquipmentScreenActions.SetCurrentEquipmentToInHand:
                iAction = new SetCurrentEquipmentToInHandAction();
                break;
            default:
                break;
        }


        return iAction;
    }
}
