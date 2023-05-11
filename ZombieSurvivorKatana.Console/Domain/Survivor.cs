using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.OrangeSkills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.YellowSkills;

[assembly: InternalsVisibleToAttribute("ZombieZurvivorKatana.Tests")]
namespace ZombieSurvivorKatana.ConsoleApp.Domain;

public class Survivor
{
    public string Name { get; private set; }
    public int Wounds { get; internal set; }
    public int MaxWounds { get; internal set; }
    internal int ActionsPerTurn { get; private set; }
    public bool Active { get; internal set; }
    private List<Equipment> _equipment { get; set; }
    public IReadOnlyList<Equipment> Equipment => _equipment.AsReadOnly();
    internal int MaxEquipment { get; set; }
    private List<Action<Event>> Subscibers { get; set; } = new List<Action<Event>>();
    public int Experience { get; private set; }
    public Level Level { get; internal set; }
    public SkillTree SkillTree { get; private set; }
    public int Dodge { get; private set; }

    public Survivor(string name)
    {
        Name = name;
        SetBaseValues();
    }

    public void AddEquipment(Equipment newEquipment)
    {
        var equipmentCount = SurvivorHasActiveSkill(typeof(Hoard)) ? MaxEquipment + 1 : MaxEquipment;
        if (_equipment.Count == equipmentCount)
            PushEvent(new InvalidOperationEvent("Equipment is full"));
        else
        {
            _equipment.Add(newEquipment);
            SpendAction();
            PushEvent(new SuccessfulOperationEvent($"{newEquipment.Name} added to {Name}'s inventory"));
        }
    }

    public void DropEquipment(Equipment equipment)
    {
        if (_equipment.Count > 0)
        {
            _equipment.Remove(equipment);
            SpendAction();
            PushEvent(new SuccessfulOperationEvent($"{Name} dropped {equipment.Name}"));
        }
        else
            PushEvent(new InvalidOperationEvent($"{Name} does not have any equipment currently"));
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
        CombatRound();
        if (Active)
        {
            GainExperience();
            SpendAction();
        }
    }

    public void ResetActionsPerTurn()
    {
        if (SurvivorHasActiveSkill(typeof(PlusOneAction)))
            ActionsPerTurn = BaseSurvivor.ActionsPerTurn + 1;
        else
            ActionsPerTurn = 3;
    }

    internal void RecieveWound()
    {
        if (Active)
        {
            Wounds++;
            if (Wounds == MaxWounds && !SurvivorHasActiveSkill(typeof(CheatDeath)))
            {
                Active = false;
                PushEvent(new SurvivorDeathEvent(this));
            }
            else if (Wounds == MaxWounds && SurvivorHasActiveSkill(typeof(CheatDeath)))
            {
                Wounds--;
                var cheatDeathSkill = SkillTree.UnlockedSkills.FirstOrDefault(s => s.GetType() == typeof(Tough));
                cheatDeathSkill.Applied = false;
                PushEvent(new SuccessfulOperationEvent($"{this.Name} used Cheat Death Skill to avoid death"));
            }
            else
            {
                MaxEquipment = BaseSurvivor.MaxEquipment - Wounds;
                PushEvent(new SurvivorWoundedEvent(this));
                if (MaxEquipment < _equipment.Count)
                    MaxEquipmentExceeded();
            }
        }
        else
            PushEvent(new InvalidOperationEvent("Survivor is not active."));

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
        int expMultiplier = SurvivorHasActiveSkill(typeof(DoubleExp)) ? 2 : 1;
        for (int i = 0; i < expMultiplier; i++)
        {
            Experience++;
            if (LevelUpCriteriaMet())
                LevelUp();
            if (SkillUpCriteriaMet())
            {
                SkillTree.SkillUp(Experience);
                foreach (var skill in SkillTree.UnlockedSkills)
                {
                    if (!skill.Applied)
                        skill.ApplySkill(this);
                }
            }
        }

    }

    private bool LevelUpCriteriaMet()
    {
        if (Experience == 7 || Experience == 19 || Experience == 43)
            return true;
        else
            return false;
    }

    private bool SkillUpCriteriaMet()
    {
        if (Experience == 7 || Experience == 19 || Experience == 43 ||
            Experience == 61 || Experience == 86 || Experience == 104 || Experience == 129)
            return true;
        else
            return false;
    }

    private void LevelUp()
    {
        if (Level == Level.Blue)
            Level = Level.Yellow;
        else if (Level == Level.Yellow)
            Level = Level.Orange;
        else if (Level == Level.Orange)
            Level = Level.Red;

        PushEvent(new SurvivorLevelUpEvent(this));
    }

    private void SpendAction()
    {
        int actions = SurvivorHasActiveSkill(typeof(PlusOneAction)) ? ActionsPerTurn + 1 : ActionsPerTurn;
        if (actions > 0)
            ActionsPerTurn--;
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
        var isInHand = _equipment.Any(x => x.EquipmentType == EquipmentTypeEnum.InHand);
        return isInHand;
    }

    private void SetBaseValues()
    {
        Wounds = BaseSurvivor.Wounds;
        MaxWounds = BaseSurvivor.MaxWounds;
        ActionsPerTurn = BaseSurvivor.ActionsPerTurn;
        Active = BaseSurvivor.Active;
        _equipment = BaseSurvivor.Equipment;
        MaxEquipment = BaseSurvivor.MaxEquipment;
        Experience = BaseSurvivor.Experience;
        Level = BaseSurvivor.Level;
        SkillTree = BaseSurvivor.SkillTree;
        Dodge = BaseSurvivor.Dodge;
    }

    private bool SurvivorHasActiveSkill(Type skill)
    {
        if (SkillTree.UnlockedSkills.Any(s => s.GetType() == skill.GetType() && s.Applied))
            return true;
        else
            return false;
    }

    private int Roll()
    {
        var random = new Random();
        var roll = random.Next(1, 11);
        return roll;
    }

    private void CombatRound()
    {
        if (!Active)
            throw new InvalidOperationException("Survivor is not active");

        var dodgeModifier = IsEquipmentInHand() ? 2 : 0;
        var roll = Roll();
        if (roll > Dodge + dodgeModifier && !SurvivorHasActiveSkill(typeof(Tough)))
            RecieveWound();
        else if (roll > Dodge + dodgeModifier && SurvivorHasActiveSkill(typeof(Tough)))
        {
            var toughSkill = SkillTree.UnlockedSkills.FirstOrDefault(s => s.GetType() == typeof(Tough));
            toughSkill.Applied = false;
        }

        PushEvent(new SurvivorKilledZombieEvent(this));
    }
}
