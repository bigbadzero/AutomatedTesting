using Shouldly;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests;

public class SurvivorCreationTests
{
    [Fact]
    public void SurvivorCreated_WithPassedName()
    {
        string name = "Nick";
        var nick = new Survivor(name);

        nick._name.ShouldBe(name);
    }

    [Fact]
    public void SurvivorCreated_With0Wounds()
    {
        var nick = new Survivor("Nick");

        nick._wounds.ShouldBe(0);
    }

    [Fact]
    public void SurvivorCreated_With3ActionsPerTurn()
    {
        var nick = new Survivor("Nick");

        nick._actionsPerTurn.ShouldBe(3);
    }

    [Fact]
    public void SurvivorCreated_Alive()
    {
        var nick = new Survivor("Nick");

        nick._alive.ShouldBe(true);
    }
}
