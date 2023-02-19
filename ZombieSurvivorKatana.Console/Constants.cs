using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class Constants
    {
        public string MaxEquipmentMessage { get; }
        public string MaxInHandEquipmentMessage { get; }
        public Constants()
        {
            MaxEquipmentMessage = SetMaxEquipmentMessage();
            MaxInHandEquipmentMessage= SetMaxInHandEquipmentMessage();
        }

        private string SetMaxEquipmentMessage()
        {
            var sb = new StringBuilder();
            sb.Append("You are at the maximum amount of equipment you can currently hold.");
            sb.Append("Would you like to discard a piece of equipment");
            return sb.ToString();
        }

        private string SetMaxInHandEquipmentMessage()
        {
            var sb = new StringBuilder();
            sb.Append("You already have the maximum amount of InHand Equipment.");
            sb.Append("Would you like to swap out an In Hand piece of Equipment");
            return sb.ToString();
        }
    }
}
