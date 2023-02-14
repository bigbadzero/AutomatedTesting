using Shouldly;
using ZombieSurvivorKata.ConsoleApp;
using ZombieSurvivorKata.Tests.Mocks;

namespace ZombieSurvivorKata.Tests;

public class SurvivorCreationTests
{
    public readonly IUserInput _userInput;
    public SurvivorCreationTests()
    {
        _userInput = MockIUserInput.GetMockUserInput().Object;
    }

    [Fact]
    public void SurvivorCreated_WithPassedName()
    {
        string name = "Nick";
        var nick = new Survivor(name, _userInput);

        nick._name.ShouldBe(name);
    }

    [Fact]
    public void SurvivorCreated_With0Wounds()
    {
        var nick = new Survivor("Nick", _userInput);

        nick._wounds.ShouldBe(0);
    }

    [Fact]
    public void SurvivorCreated_With3ActionsPerTurn()
    {
        var nick = new Survivor("Nick", _userInput);

        nick._actionsPerTurn.ShouldBe(3);
    }

    [Fact]
    public void SurvivorCreated_Alive()
    {
        var nick = new Survivor("Nick", _userInput);

        nick._alive.ShouldBe(true);
    }

    [Fact]
    public void SurvivorCreated_WithMaxEqupmentCountEqualToFive()
    {
        var nick = new Survivor("Nick", _userInput);

        nick._maxEquipmentCount.ShouldBe(5);
    }
}
