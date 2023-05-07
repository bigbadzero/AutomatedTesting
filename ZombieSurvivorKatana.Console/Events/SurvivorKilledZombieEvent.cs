using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorKilledZombieEvent: Event
    {
        public SurvivorKilledZombieEvent(Survivor survivor)
        {
            EventDiscription = $"{survivor.Name} killed the zombie";
        }
    }
}
