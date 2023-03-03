using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Survivor
{
    public string Name { get; set; }
    public int Wounds { get; internal set; }
    public int ActionsPerTurn { get; set; }
    public bool Active { get; internal set; }
    public List<Equipment> Equipment { get; set; }
    public int MaxEquipment { get; internal set; }
    private List<IInHandRules> InHandRules { get; set; }
    private List<IAddEquipmentRules> AddEquipmentRules { get; set; }
    public readonly Game _game;

    public Survivor(string name, Game game)
    {
        Name = name;
        Wounds = 0;
        ActionsPerTurn = 3;
        Active = true;
        Equipment = new List<Equipment>();
        MaxEquipment = 5;
        InHandRules = new List<IInHandRules>()
        {
            new MaxInHandEquipmentNotReachedRule(),
            new MaxInHandEquipmentReachedRule()
        };
       
        _game= game;
    }

    public void PrintEquipment(List<Equipment> equipmentList)
    {
        for (int i = 0; i < equipmentList.Count; i++)
            Console.WriteLine($"{i} {equipmentList[i].Name}");
    }

    public void AddEquipment(Equipment newEquipment)
    {
        Equipment.Add(newEquipment);
    }

    public void DropEquipment(Equipment equipment)
    {
        Equipment.Remove(equipment);
    }

    public void SetEquipmentToInHand()
    {
        int indexOfEquipmentToBeInHand = 0;
        var equipmentNotInhand = Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.Reserve).ToList();
        PrintEquipment(equipmentNotInhand);
        if(Equipment.Count > 0)
        {
            indexOfEquipmentToBeInHand = _game._userInput.GetIntFromUserWithRange(0, equipmentNotInhand.Count - 1);
            var inHandEvent = new InHandEvent(this, _game._userInput, indexOfEquipmentToBeInHand);
            foreach (var rule in InHandRules.OrderBy(x => x.Priority))
            {
                if (rule.IsRuleApplicable(inHandEvent))
                    rule.ExecuteRule(inHandEvent);
            }
        }
    }

    //this method really should be private but i needed my rules to have access to it
    public Equipment GetEquipmentToDrop()
    {
        Console.WriteLine("Which piece of equipment would you like to drop");
        PrintEquipment(Equipment);
        var equipmentToDropIndex = _game._userInput.GetIntFromUserWithRange(0, Equipment.Count - 1);
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
            PrintEquipment(Equipment);
            var equipmentToDrop = GetEquipmentToDrop();
            DropEquipment(equipmentToDrop);
        }
    }

    private void Die()
    {
        Active = false;
        _game.CheckGameStatus();
    }

}
