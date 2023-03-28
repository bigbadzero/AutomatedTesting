using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.Domain;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    public int ActionsPerTurn { get; set; }
    public bool Active { get; internal set; }
    private List<Equipment> _equipment { get; set; }
    public IReadOnlyList<Equipment> Equipment => _equipment.AsReadOnly();
    public int MaxEquipment { get; internal set; }
    private List<Action<Event>> Subscibers { get; set; } = new List<Action<Event>>();
    private int Experience { get; set; } 
    private Level _level { get; set; }
    public Level Level { get { return _level; } }

    public Survivor(string name)
    {
        Name = name;
        Wounds = 0;
        ActionsPerTurn = 3;
        Active = true;
        _equipment = new List<Equipment>();
        MaxEquipment = 5;
        Experience = 0;
        _level = Level.Blue;
    }

    public void AddEquipment(Equipment newEquipment)
    {
        _equipment.Add(newEquipment);
    }

    public void DropEquipment(Equipment equipment)
    {
        _equipment.Remove(equipment);
    }

    public bool SetEquipmentToInHand(Equipment equipmentToBeInHand)
    {
        if (CanSetEquipmentToInHand())
        {
            var equipment = _equipment.Where(x => x.Id == equipmentToBeInHand.Id).FirstOrDefault();
            if (equipment != null)
                equipment.EquipmentType = EquipmentTypeEnum.InHand;
            return true;
        }
        return false;
    }

    public void SetEquipmentToReserve(Equipment equipmentToBeReserve)
    {
        var equipment = _equipment.Where(x => x.Id == equipmentToBeReserve.Id).FirstOrDefault();
        if (equipment != null)
            equipment.EquipmentType = EquipmentTypeEnum.InHand;
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
        return _equipment.Count > 0
            && _equipment.Any(x => x.EquipmentType == EquipmentTypeEnum.Reserve
            && _equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).Count() < 2);
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

    public void Kill()
    {
        GainExperience();
        if (LevelUpCriteriaMet())
        {
            LevelUp();
        }
    }

    private void GainExperience()
    {
        Experience++;
    }

    private bool LevelUpCriteriaMet()
    {
        if (Experience == 6 || Experience == 18 || Experience == 42)
            return true;
        else
            return false;
    }

    private void LevelUp()
    {
        if (_level == Level.Blue)
            _level = Level.Yellow;
        else if (_level == Level.Yellow)
            _level = Level.Orange;
        else if (_level == Level.Orange)
            _level = Level.Red;

        PushEvent(new SurvivorLevelUpEvent(this));
    }
}
