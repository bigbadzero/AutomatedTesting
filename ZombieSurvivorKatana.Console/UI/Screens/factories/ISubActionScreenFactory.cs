﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories
{
    public class ISubActionScreenFactory
    {
        public static ISubActionScreen GetSubActionScreen(GameActions action)
        {
            ISubActionScreen screen = null;
            if (action == GameActions.Equipment)
            {
                screen = new EquipmentSubActionScreen();
            }

            return screen;
        }
    }
}
