using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorLevelUpEvent: Event
    {
        public SurvivorLevelUpEvent(Survivor survivor)
        {
            EventDiscription = $"{survivor.Name} has leveled up to {survivor.Level}";
        }
    }
}
