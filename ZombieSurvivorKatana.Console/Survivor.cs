using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    public int ActionsPerTurn { get; internal set; }
    public bool Active { get; internal set; }
    public List<Equipment> Equipment { get; set; }
    public int MaxEquipment { get; internal set; }
    public IUserInput _userInput;
    private List<IInHandRules> InHandRules { get; set; }
    private List<IAddEquipmentRules> AddEquipmentRules { get; set; }

    public Survivor(string name, IUserInput userInput)
    {
        Name = name;
        Wounds = 0;
        ActionsPerTurn = 3;
        Active = true;
        Equipment = new List<Equipment>();
        MaxEquipment = 5;
        _userInput = userInput;
        InHandRules = new List<IInHandRules>()
        {
            new MaxInHandEquipmentNotReachedRule(),
            new MaxInHandEquipmentReachedRule()
        };
        AddEquipmentRules = new List<IAddEquipmentRules>()
        {
            new AddEquipmentMaxEquipmentNotReachedRule(),
            new AddEquipmentMaxEquipmentReachedRule()
        };
    }

    public void SetEquipmentToInHand(int indexOfEquipmentToBeInHand)
    {
        var inHandEvent = new InHandEvent(this, _userInput, indexOfEquipmentToBeInHand);
        foreach (var rule in InHandRules.OrderBy(x => x.Priority))
        {
            if (rule.IsRuleApplicable(inHandEvent))
                rule.ExecuteRule(inHandEvent);
        }
    }


    public void AddEquipment(Equipment newEquipment)
    {
        var addEquipmentEvent = new AddEquipmentEvent(this, newEquipment);
        foreach (var rule in AddEquipmentRules.OrderBy(x => x.Priority))
        {
            if (rule.IsRuleApplicable(addEquipmentEvent))
                rule.ExecuteRule(addEquipmentEvent);
        }
    }

    public void PrintCurrentEquipment()
    {
        for (int i = 0; i < Equipment.Count; i++)
            Console.WriteLine($"{i}) {Equipment[i].Name}");
    }

    public void PrintCurrentInHandEquipment()
    {
        var inHandEquipment = Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
        for (int i = 0; i < inHandEquipment.Count(); i++)
            Console.WriteLine($"{i}) {inHandEquipment[i].Name}");
    }

    public void DropEquipment(Equipment equipment)
    {

        Equipment.Remove(equipment);
        Console.WriteLine($"{equipment.Name} dropped");
    }

    public Equipment GetEquipmentToDrop()
    {
        Console.WriteLine("Which weapon would you like to drop");
        PrintCurrentEquipment();
        var equipmentToDropIndex = _userInput.GetIntFromUserWithRange(0, Equipment.Count - 1);
        var equipmentToDrop = Equipment[equipmentToDropIndex];
        return equipmentToDrop;
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
        if (Equipment.Count > MaxEquipment)
        {
            Console.WriteLine("Because of your wounds you can no longer carry this much equipment");
            var equipmentToDrop = GetEquipmentToDrop();
            DropEquipment(equipmentToDrop);
        }
    }

    private void Die()
    {
        Active = false;
    }
}
