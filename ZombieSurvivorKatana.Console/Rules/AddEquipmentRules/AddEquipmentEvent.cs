using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules
{
    public class AddEquipmentEvent
    {
        public Survivor Survivor;
        public Equipment NewEquipment;

        public AddEquipmentEvent(Survivor survivor, Equipment newEquipment)
        {
            Survivor= survivor;
            NewEquipment= newEquipment;
        }
    }
}
