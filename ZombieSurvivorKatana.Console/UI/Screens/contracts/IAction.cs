using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts
{
    public interface IAction
    {
        public void PerformAction(Survivor survivor);
    }
}
