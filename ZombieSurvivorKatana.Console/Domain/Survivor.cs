using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain;

[assembly: InternalsVisibleToAttribute("ZombieZurvivorKatana.Tests")]
namespace ZombieSurvivorKatana.ConsoleApp.Domain;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    private int _actionsPerTurn { get; set; }
    public int ActionsPerTurn { get => _actionsPerTurn; }
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
        _actionsPerTurn = 3;
        Active = true;
        _equipment = new List<Equipment>();
        MaxEquipment = 5;
        Experience = 0;
        _level = Level.Blue;
    }

    public void AddEquipment(Equipment newEquipment)
    {
        if(Equipment.Count == MaxEquipment)
        {
            PushEvent(new InvalidOperationEvent("Equipment is full"));
        }
        else
        {
            _equipment.Add(newEquipment);
            SpendAction();
            PushEvent(new SuccessfulOperationEvent($"{newEquipment.Name} added to {Name}'s inventory"));
        }
    }

    public void DropEquipment(Equipment equipment)
    {
        if(Equipment.Count > 0)
        {
            _equipment.Remove(equipment);
            SpendAction();
            PushEvent(new SuccessfulOperationEvent($"{Name} dropped {equipment.Name}"));
        }
        else
        {
            PushEvent(new InvalidOperationEvent($"{Name} does not have any equipment currently"));
        }
    }

    public void SetEquipmentToInHand(Equipment equipmentToBeInHand)
    {
        if (CanSetEquipmentToInHand())
        {
            var equipment = _equipment.Where(x => x.Id == equipmentToBeInHand.Id).FirstOrDefault();
            if (equipment != null)
                equipment.EquipmentType = EquipmentTypeEnum.InHand;
            SpendAction();
        }
    }

    public void SetEquipmentToReserve(Equipment equipmentToBeReserve)
    {
        var equipment = _equipment.Where(x => x.Id == equipmentToBeReserve.Id).FirstOrDefault();
        if (equipment != null)
            equipment.EquipmentType = EquipmentTypeEnum.InHand;
        SpendAction();
    }

    public void Subscribe(Action<Event> action)
    {
        Subscibers.Add(action);
    }

    public void Attack()
    {
        if (Active)
        {
            var random = new Random();
            var roll = random.Next(1, 11);
            if (roll > 7) //30% chance to recieve wound
                RecieveWound();
            if(Active)//checks to see if active is still true;
            {
                GainExperience();
                if (LevelUpCriteriaMet())
                    LevelUp();
                SpendAction();
            }
            
        }
            
        else
            PushEvent(new InvalidOperationEvent("Survivor is not active"));
        
    }

    public void ResetActionsPerTurn()
    {
        _actionsPerTurn = 3;
    }

    internal void RecieveWound()
    {
        if(Active)
        {
            Wounds++;
            if (Wounds == 2)
            {
                Active = false;
                PushEvent(new SurvivorDeathEvent(this));
            }
            else
            {
                MaxEquipment = MaxEquipment - Wounds;
                PushEvent(new SurvivorWoundedEvent(this));
                if (MaxEquipment < _equipment.Count)
                    MaxEquipmentExceeded();
            }
        }
        else
        {
            PushEvent(new InvalidOperationEvent("Survivor is not active."));
        }
        
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

    private void SpendAction()
    {
        if (_actionsPerTurn > 0)
            _actionsPerTurn--;
        else
            throw new InvalidOperationException("Actions Per Turn Already 0");
    }

    private void MaxEquipmentExceeded()
    {
        var reserveEquipment = _equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.Reserve).ToList();
        var count = reserveEquipment.Count();
        var random = new Random();  
        var index = random.Next(reserveEquipment.Count());
        var equipment = reserveEquipment[index];
        _equipment.Remove(equipment);
        PushEvent(new SurvivorMaxEquipmentExceededEvent(this, equipment));
    }
}
