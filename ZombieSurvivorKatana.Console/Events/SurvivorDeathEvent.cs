using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorDeathEvent: Event
    {
        public SurvivorDeathEvent(Survivor survivor)
        {
            EventDiscription = $"{survivor.Name} has died tragically due to their wounds.";
        }
    }
}
