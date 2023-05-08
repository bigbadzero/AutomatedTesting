namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills;

public class PlusOneMaxWounds : Skill
{
    public Level Level => Level.Red;
    public bool Applied { get; set; } = false;
    public void ApplySkill(Survivor survivor)
    {
        survivor.MaxWounds++;
        Applied = true;
        survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} gained Plus 1 Max Wounds Skill"));
    }
}
