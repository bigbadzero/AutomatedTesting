using RPGCombatKata.ConsoleApp;
using Shouldly;

namespace RPGCombatKata.Tests;

public class CharacterHealingTests
{
    [Fact]
    public void SelfHealing_Occurred()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();

        character1.Health = 500;
        character1.HealSelf(100);

        character2.Health.ShouldBeGreaterThan(500);
    }

    [Fact]
    public void SelfHealing_OverHealingCannotOccur()
    {
        var character1 = new MeleeCharacter();

        character1.Health = 400;
        character1.HealSelf(5000);
        character1.Health.ShouldBe(1000);
    }

    [Fact]
    public void SelfHealing_DeadCharactersCannotRecieveHealing()
    {
        var character1 = new MeleeCharacter();

        character1.IsDead();
        character1.HealSelf(500);
        character1.Alive.ShouldBeFalse();
        character1.Health.ShouldBe(0);
    }

    [Fact]
    public void AllyHealing_Occurred()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();
        character1.JoinFaction("Horde");
        character2.JoinFaction("Horde");

        character1.Health = 500;
        character2.HealAlly(100, character1);

        character1.Health.ShouldBeGreaterThan(500);
    }

    [Fact]
    public void AllyHealing_DoesntOccurWhenNotAllies()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();
        character1.JoinFaction("Horde");
        character2.JoinFaction("Alliance");

        character1.Health = 500;
        character2.HealAlly(100, character1);

        character1.Health.ShouldBe(500);
    }

    [Fact]
    public void AllyHealing_OverHealingCannotOccur()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();
        character1.JoinFaction("Horde");
        character2.JoinFaction("Horde");
        character1.Health = 400;
        character2.HealAlly(5000, character1);

        character1.Health.ShouldBe(1000);
    }

    [Fact]
    public void AllyHealing_DeadCharactersCannotRecieveHealing()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();
        character1.JoinFaction("Horde");
        character2.JoinFaction("Horde");

        character1.IsDead();
        character2.HealAlly(500, character1);

        character1.Alive.ShouldBeFalse();
        character1.Health.ShouldBe(0);
    }

    [Fact]
    public void AllyHealing_DeadCharactersCannotGiveHealing()
    {
        var character1 = new MeleeCharacter();
        var character2 = new MeleeCharacter();
        character1.JoinFaction("Horde");
        character2.JoinFaction("Horde");
        character2.Health = 500;
        character1.IsDead();
        character1.HealAlly(100, character2);

        character2.Health.ShouldBe(500);
    }
}
