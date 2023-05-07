using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorCreatedEvent: Event
    {
        public SurvivorCreatedEvent(Survivor survivor)
        {
            EventDiscription = $"{survivor.Name} was added to the game!";
        }
    }
}
