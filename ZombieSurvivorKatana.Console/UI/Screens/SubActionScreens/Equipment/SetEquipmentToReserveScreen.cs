using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class SetEquipmentToReserveScreen : SurvivorScreen, IScreen
{
    public SetEquipmentToReserveScreen(Game game, Survivor survivor) : base(game, survivor) { }

    public void DisplayScreenMessage()
    {
        Console.WriteLine("Which piece of equipment should be In Reserve");
    }

    public void Execute()
    {
        ClearScreen();
        var equipmentList = _survivor.Equipment;
        if (equipmentList.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).Count() > 0)
        {
            DisplayScreenMessage();
            var inHandScreen = new ViewInHandEquipmentScreen(_game, _survivor);
            inHandScreen.Execute();
            var InHandEquipment = equipmentList.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            var indexOfEquipment = _game._userInput.GetIntFromUserWithRange(1, InHandEquipment.Count());
            var equipment = InHandEquipment[indexOfEquipment - 1];
            _survivor.SetEquipmentToInHand(equipment);
            Console.WriteLine($"{_survivor.Name} set {equipment.Name} to InHand");
        }
    }
}
