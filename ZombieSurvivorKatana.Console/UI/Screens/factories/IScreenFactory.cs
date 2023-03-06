using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories
{
    public class IScreenFactory
    {
        public static IScreen GetSurvivorScreen(Enum action, Game game, Survivor survivor)
        {
            IScreen screen = null;
            switch (action)
            {
                case ScreenActions.Equipment:
                    screen = new EquipmentSubActionScreen(game, survivor);
                    break;
                default:
                    break;
            }

            return screen;
        }
    }
}
