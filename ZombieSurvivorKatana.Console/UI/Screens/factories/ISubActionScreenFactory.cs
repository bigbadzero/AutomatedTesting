using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Actions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.Equipment;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories
{
    public class ISubActionScreenFactory
    {
        public static ISubActionScreen GetSubActionScreen(GameActions action)
        {
            ISubActionScreen screen = null;
            if (action == GameActions.ModifyEquipment)
            {
                screen = new EquipmentSubActionScreen();
            }

            return screen;
        }
    }
}
