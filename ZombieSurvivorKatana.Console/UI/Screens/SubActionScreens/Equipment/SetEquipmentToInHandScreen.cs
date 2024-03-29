﻿using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

public class SetEquipmentToInHandScreen : SurvivorScreen, IScreen
{
    public SetEquipmentToInHandScreen(Game game, Survivor survivor) : base(game, survivor) { }

    public void DisplayScreenMessage()
    {
        Console.WriteLine("Which piece of equipment should be InHand");
    }

    public void Execute()
    {
        ClearScreen();
        var equipmentList = _survivor.Equipment;
        if (equipmentList.Count > 0
            && equipmentList.Any(x => x.EquipmentType == EquipmentTypeEnum.Reserve
            && equipmentList.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).Count() < 2))
        {
            DisplayScreenMessage();
            var inReserveScreen = new ViewInReserveEquipmentScreen(_game, _survivor);
            inReserveScreen.Execute();
            var reserveEquipment = equipmentList.Where(x => x.EquipmentType == EquipmentTypeEnum.Reserve).ToList();
            var indexOfEquipment = _game._userInput.GetIntFromUserWithRange(1, reserveEquipment.Count());
            var equipment = reserveEquipment[indexOfEquipment - 1];
            _survivor.SetEquipmentToInHand(equipment);
            Console.WriteLine($"{_survivor.Name} set {equipment.Name} to InHand");
        }
        else
            Console.WriteLine("Do Not Meet Criteria to set equipment to INHand");
    }
}
