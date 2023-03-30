using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class InvalidOperationEvent: Event
    {
        public InvalidOperationEvent(string message)
        {
            EventDiscription = $"Invalid operation {message}";
        }
    }
}
