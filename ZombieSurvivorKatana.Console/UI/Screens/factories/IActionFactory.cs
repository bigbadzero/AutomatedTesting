using ZombieSurvivorKatana.ConsoleApp.Actions.SubScreenActions;
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
            case EquipmentActions.PrintEquipment:
                iAction = new ViewEquipmentAction();
                break;
            case EquipmentActions.PrintInHandEquipment:
                iAction = new ViewInHandEquipmentAction();
                break;
            case EquipmentActions.AddEquipment:
                iAction = new AddEquipmentAction();
                break;
            case EquipmentActions.DropEquipment:
                iAction = new DropEquipmentAction();
                break;
            case EquipmentActions.SetCurrentEquipmentToInHand:
                iAction = new SetCurrentEquipmentToInHandAction();
                break;
            default:
                break;
        }


        return iAction;
    }
}
