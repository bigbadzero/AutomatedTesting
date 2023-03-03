using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Actions.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment
{
    public class EquipmentSubActionScreen : ISubActionScreen
    {
        public Enum GetSubScreenAction(IUserInput userInput, Survivor survivor)
        {
            Console.WriteLine($"What Equipment Action Would {survivor.Name} Like To Perform?");
            var equipmentActions = Enum.GetNames(typeof(ModifyEquipmentActions));
            for (int i = 0; i < equipmentActions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {equipmentActions[i]}");
            }
            var modifyEquipmentActionIndex = userInput.GetIntFromUserWithRange(1, equipmentActions.Length);
            var gameAction = (ModifyEquipmentActions)modifyEquipmentActionIndex;
            return gameAction;
        }

        //perform action
        public IAction GetIAction(Enum modifyEquipmentAction)
        {
            // based on this screen it will use a factory to create an IAction
            var iAction = IActionFactory.GetIAction(modifyEquipmentAction);
            return iAction;
        }
    }
}
