namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public interface IInHandRules
{
    int Priority { get; }
    public bool IsRuleApplicable(InHandEvent inHandEvent);
    public void ExecuteRule(InHandEvent inHandEvent);
}
