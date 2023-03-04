using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    public int ActionsPerTurn { get; set; }
    public bool Active { get; internal set; }
    private List<Equipment> Equipment { get; set; }
    public int MaxEquipment { get; internal set; }
    public readonly Game _game;

    public Survivor(string name, Game game)
    {
        Name = name;
        Wounds = 0;
        ActionsPerTurn = 3;
        Active = true;
        Equipment = new List<Equipment>();
        MaxEquipment = 5;
        _game= game;
    }

    public void AddEquipment(Equipment newEquipment)
    {
        Equipment.Add(newEquipment);
    }

    public void DropEquipment(Equipment equipment)
    {
        Equipment.Remove(equipment);
    }

    public void SetEquipmentToInHand(Equipment equipmentToBeInHand)
    {
        var equipment = Equipment.Where(x => x.Id == equipmentToBeInHand.Id).FirstOrDefault();
        if (equipment != null)
            equipment.EquipmentType = EquipmentTypeEnum.InHand;
    }

    public void SetEquipmentToReserve(Equipment equipmentToBeReserve)
    {
        var equipment = Equipment.Where(x => x.Id == equipmentToBeReserve.Id).FirstOrDefault();
        if (equipment != null)
            equipment.EquipmentType = EquipmentTypeEnum.InHand;
    }

    public List<Equipment> GetEqupment()
    {
        return Equipment;
    }

    private void RecieveWound()
    {
        Wounds++;
        if (Wounds == 2)
            Die();
        MaxEquipment = MaxEquipment - Wounds;
    }

    private void Die()
    {
        Active = false;
        _game.CheckGameStatus();
    }

}
