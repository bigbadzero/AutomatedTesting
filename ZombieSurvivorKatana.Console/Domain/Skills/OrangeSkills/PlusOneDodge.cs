namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.OrangeSkills;

public class PlusOneDodge : Skill
{
    public bool Applied { get; set; } = false;

    public Level Level => Level.Orange;

    public void ApplySkill(Survivor survivor)
    {
        Applied = true;
        survivor.Dodge++;
        survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} gained Plus 1 Dodge skill"));
    }
}
