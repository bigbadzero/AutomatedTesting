using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens
{
    public class ViewInHandEquipmentScreen : SurvivorScreen, IScreen
    {
        public ViewInHandEquipmentScreen(Game game, Survivor survivor) : base(game, survivor)
        {
        }

        public void DisplayScreenMessage()
        {
            var inHandEquipment = _survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand);
            if (inHandEquipment.Count() == 0)
                Console.WriteLine($"{_survivor.Name} doesnt have any equipment in hand");
            else
            {
                for (int i = 0; i < inHandEquipment.Count(); i++)
                    Console.WriteLine($"{i + 1} {_survivor.GetEqupment()[i].Name}");
            }
        }

        public void Execute()
        {
            ClearScreen();
            DisplayScreenMessage();
        }

        public Enum GetAction()
        {
            throw new NotImplementedException();
        }

        public void PerformAction(Survivor survivor, Game game)
        {
            var inHandEquipment = survivor.GetEqupment().Where(x => x.EquipmentType == EquipmentTypeEnum.InHand);
            if(inHandEquipment.Count() == 0)
                Console.WriteLine($"{survivor.Name} doesnt have any equipment in hand");
            else
            {
                for (int i = 0; i < inHandEquipment.Count(); i++)
                    Console.WriteLine($"{i + 1} {survivor.GetEqupment()[i].Name}");
            }
        }
    }
}
