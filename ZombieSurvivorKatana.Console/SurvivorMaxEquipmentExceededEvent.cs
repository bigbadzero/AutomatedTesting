using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class SurvivorMaxEquipmentExceededEvent: Event
    {
        public SurvivorMaxEquipmentExceededEvent(Survivor survivor, Equipment equipment)
        {
            EventDiscription = $"Due to wounds {survivor.Name} has dropped their {equipment.Name}";
        }
    }
}
