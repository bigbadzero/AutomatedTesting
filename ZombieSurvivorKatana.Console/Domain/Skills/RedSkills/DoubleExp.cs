namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills;

public class DoubleExp : Skill
{
    public bool Applied { get; set; } = false;

    public Level Level => Level.Red;

    public void ApplySkill(Survivor survivor)
    {
        survivor.DoubleExp = true;
        Applied = true;
        survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} has gained Double Exp Skill"));
    }
}
