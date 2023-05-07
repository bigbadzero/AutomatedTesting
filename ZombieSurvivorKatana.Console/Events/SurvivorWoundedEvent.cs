using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorWoundedEvent: Event
    {
        public SurvivorWoundedEvent(Survivor survivor)
        {
            EventDiscription = $"{survivor.Name} is wounded";
        }
    }
}
