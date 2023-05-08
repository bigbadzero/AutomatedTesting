﻿namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.OrangeSkills;

public class Hoard : Skill
{
    public Level Level => Level.Orange;

    public bool Applied { get; set; } = false;

    public void ApplySkill(Survivor survivor)
    {
        survivor.MaxEquipment++;
        Applied = true;
        survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} gained Hoard Skill"));
    }
}