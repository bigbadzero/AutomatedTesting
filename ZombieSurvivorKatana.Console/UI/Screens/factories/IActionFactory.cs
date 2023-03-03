using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Actions.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment.Actions;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories
{
    public class IActionFactory
    {
        public static IAction GetIAction(Enum action)
        {
            IAction iAction = null;
            switch (action)
            {
                case ModifyEquipmentActions.PrintEquipment:
                    iAction = new PrintEquipmentAction();
                    break;
                case ModifyEquipmentActions.PrintInHandEquipment:
                    iAction = new PrintInHandEquipmentAction();
                    break;
                default:
                    break;
            }


            return iAction;
        }
    }
}
