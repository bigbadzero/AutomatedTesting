using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts
{
    public interface IAction
    {
        public void PerformAction(Survivor survivor);
    }
}
