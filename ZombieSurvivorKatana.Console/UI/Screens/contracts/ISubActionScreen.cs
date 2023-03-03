using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Actions;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts
{
    public interface ISubActionScreen
    {
        public Enum GetSubScreenAction(IUserInput userInput, Survivor survivor);
        public IAction GetIAction(Enum action);
    }
}
