using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens
{
    public class EquipmentSubActionScreen : ISubActionScreen
    {
        public Enum GetSubScreenAction(Survivor survivor, Game game)
        {
            Console.WriteLine($"\nWhat Equipment Action Would {survivor.Name} Like To Perform?");
            var equipmentActions = Enum.GetNames(typeof(EquipmentActions));
            for (int i = 0; i < equipmentActions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {equipmentActions[i]}");
            }
            var modifyEquipmentActionIndex = game._userInput.GetIntFromUserWithRange(1, equipmentActions.Length);
            var gameAction = (EquipmentActions)modifyEquipmentActionIndex;
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
