﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts
{
    public interface ISubActionScreen
    {
        public Enum GetSubScreenAction(Survivor survivor, Game game);
        public IAction GetIAction(Enum action);
    }
}
