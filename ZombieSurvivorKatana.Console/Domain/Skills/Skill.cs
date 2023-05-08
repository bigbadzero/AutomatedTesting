namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills;

public interface Skill
{
    public bool Applied { get; set; }
    public Level Level { get; }
    public void ApplySkill(Survivor survivor);
}
