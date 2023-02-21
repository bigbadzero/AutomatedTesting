namespace ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;

public interface IAddEquipmentRules
{
    int Priority { get; }
    public bool IsRuleApplicable(AddEquipmentEvent addEquipmentEvent);
    public void ExecuteRule(AddEquipmentEvent addEquipmentEvent);
}
