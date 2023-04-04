using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class Event
    {
        public string EventDiscription { get; set; } = string.Empty;
        public Survivor? Survivor { get; set; }
    }
}
