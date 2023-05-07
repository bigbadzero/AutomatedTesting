using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills;

[assembly: InternalsVisibleToAttribute("ZombieZurvivorKatana.Tests")]
namespace ZombieSurvivorKatana.ConsoleApp.Domain;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    internal int MaxWounds { get; set; }
    internal int _actionsPerTurn { get; set; }
    internal int MaxActionsPerTurn { get; set; }
    public int ActionsPerTurn { get => _actionsPerTurn; }
    public bool Active { get; internal set; }
    private List<Equipment> _equipment { get; set; }
    public IReadOnlyList<Equipment> Equipment => _equipment.AsReadOnly();
    internal int MaxEquipment { get; set; }
    private List<Action<Event>> Subscibers { get; set; } = new List<Action<Event>>();
    private int _experience { get; set; }
    public int Experience { get { return _experience; } }
    private Level _level { get; set; }
    public Level Level { get { return _level; } }
    private SkillTree SkillTree { get; set; } = new SkillTree();
    internal bool CheatDeath { get; set; }
    internal bool DoubleExp { get; set; }
    internal bool Tough { get; set; }
    internal int Dodge { get; set; }

    public Survivor(string name)
    {
        Name = name;
        Wounds = 0;
        MaxActionsPerTurn = 3;
        _actionsPerTurn = 3;
        Active = true;
        _equipment = new List<Equipment>();
        MaxEquipment = 5;
        _experience = 0;
        _level = Level.Blue;
        MaxWounds = 3;
        CheatDeath = false;
        DoubleExp = false;
        Tough = false;
        Dodge = 7;
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
            var dodgeModifier = 0;
            if (IsEquipmentInHand())
                dodgeModifier = 2;
            var random = new Random();
            var roll = random.Next(1, 11);
            if (roll > Dodge + dodgeModifier & !Tough)
                RecieveWound();
            if (roll > Dodge + dodgeModifier & Tough)
                Tough = false;
            if (Active)//checks to see if active is still true;
            {
                PushEvent(new SurvivorKilledZombieEvent(this));
                GainExperience();
                if (DoubleExp)
                    GainExperience();
                SpendAction();
            }
        }
        else
            PushEvent(new InvalidOperationEvent("Survivor is not active"));
    }

    public void ResetActionsPerTurn()
    {
        _actionsPerTurn = MaxActionsPerTurn;
    }

    internal void RecieveWound()
    {
        if(Active)
        {
            Wounds++;
            if (Wounds == MaxWounds && !CheatDeath)
            {
                Active = false;
                PushEvent(new SurvivorDeathEvent(this));
            }
            else if(Wounds == MaxWounds && !CheatDeath)
            {
                Wounds--;
                CheatDeath = false;
                PushEvent(new SuccessfulOperationEvent($"{this.Name} used Cheat Death Skill to avoid death"));
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

    internal void PushEvent(Event @event)
    {
        foreach (var subscriber in Subscibers)
        {
            subscriber(@event);
        }
    }

    internal void GainExperience()
    {
        _experience++;
        if (LevelUpCriteriaMet())
            LevelUp();
        if (SkillUpCriteriaMet())
        {
            SkillTree.SkillUp(_experience);
            foreach(var skill in SkillTree.UnlockedSkills)
            {
                if (!skill.Applied)
                    skill.ApplySkill(this);
            }
        }
            
    }

    private bool LevelUpCriteriaMet()
    {
        if (_experience == 7 || _experience == 19 || _experience == 43)
            return true;
        else
            return false;
    }

    private bool SkillUpCriteriaMet()
    {
        if (_experience == 7 || _experience == 19 || _experience == 43 || 
            _experience == 61 || _experience == 86 || _experience == 104 || _experience == 129) 
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

    private bool IsEquipmentInHand()
    {
        var isInHand = Equipment.Any(x => x.EquipmentType == EquipmentTypeEnum.InHand);
        return isInHand;
    }
}
