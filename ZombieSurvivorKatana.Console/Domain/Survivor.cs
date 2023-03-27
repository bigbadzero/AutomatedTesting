using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.Domain;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    public int ActionsPerTurn { get; set; }
    public bool Active { get; internal set; }
    private List<Equipment> Equipment { get; set; }
    public int MaxEquipment { get; internal set; }
    private List<Action<Event>> Subscibers { get; set; } = new List<Action<Event>>();

    public Survivor(string name)
    {
        Name = name;
        Wounds = 0;
        ActionsPerTurn = 3;
        Active = true;
        Equipment = new List<Equipment>();
        MaxEquipment = 5;
    }

    public void AddEquipment(Equipment newEquipment)
    {
        Equipment.Add(newEquipment);
    }

    public void DropEquipment(Equipment equipment)
    {
        Equipment.Remove(equipment);
    }

    public bool SetEquipmentToInHand(Equipment equipmentToBeInHand)
    {
        if (CanSetEquipmentToInHand())
        {
            var equipment = Equipment.Where(x => x.Id == equipmentToBeInHand.Id).FirstOrDefault();
            if (equipment != null)
                equipment.EquipmentType = EquipmentTypeEnum.InHand;
            return true;
        }
        return false;
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

    internal void RecieveWound()
    {
        Wounds++;
        if (Wounds == 2)
        {
            Active = false;
            PushEvent(new SurvivorDeathEvent(this)); 
        }
        MaxEquipment = MaxEquipment - Wounds;
    }

    private bool CanSetEquipmentToInHand()
    {
        return Equipment.Count > 0
            && Equipment.Any(x => x.EquipmentType == EquipmentTypeEnum.Reserve
            && Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).Count() < 2);
    }

    private void PushEvent(Event @event)
    {
        foreach (var subscriber in Subscibers)
        {
            subscriber(@event);
        }
    }

    public void Subscribe(Action<Event> action)
    {
        Subscibers.Add(action);
    }

   
}
