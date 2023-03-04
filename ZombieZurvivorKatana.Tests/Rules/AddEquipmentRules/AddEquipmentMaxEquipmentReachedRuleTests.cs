using Moq;
using Shouldly;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieZurvivorKatana.Tests.Mocks;

namespace ZombieZurvivorKatana.Tests.Rules.AddEquipmentRules;

public class AddEquipmentMaxEquipmentReachedRuleTests
{
    public readonly Mock<IUserInput> _userInputMock;
    public AddEquipmentMaxEquipmentReachedRuleTests()
    {
        _userInputMock = IUserInputMock.GetBaseMockUserInput();
    }

    [Fact]
    public void IsRuleApplicable_False()
    {
        var game = new Game(_userInputMock.Object);
        var survivor = new Survivor("Nick", game);
        var equipment = new Equipment("axe");
        var addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
        var MaxEquipmentReached = new AddEquipmentMaxEquipmentReachedRule();

        var result = MaxEquipmentReached.IsRuleApplicable(addEquipmentEvent);

        result.ShouldBeFalse();
    }

    [Fact]
    public void IsRuleApplicable_True()
    {
        var equipmentNames = new List<string>()
        {
            "axe",
            "sword",
            "shield",
            "spear",
            "bow"
        };
        var game = new Game(_userInputMock.Object);
        var survivor = new Survivor("Nick", game);
        AddEquipmentEvent addEquipmentEvent;
        var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
        foreach (var name in equipmentNames)
        {
            var equipment = new Equipment(name);
            addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            if (MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent))
                MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
        }
        var gun = new Equipment("gun");
        addEquipmentEvent = new AddEquipmentEvent(survivor, gun);
        var maxEquipmentReached = new AddEquipmentMaxEquipmentReachedRule();

        var result = maxEquipmentReached.IsRuleApplicable(addEquipmentEvent);

        result.ShouldBeTrue();
    }

    [Fact]
    public void ExecuteRule_PromptsUserToDropEquipment()
    {
        var equipmentNames = new List<string>()
        {
            "axe",
            "sword",
            "shield",
            "spear",
            "bow"
        };
        var game = new Game(_userInputMock.Object);
        var survivor = new Survivor("Nick", game);
        AddEquipmentEvent addEquipmentEvent;
        var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
        foreach (var name in equipmentNames)
        {
            var equipment = new Equipment(name);
            addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            if (MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent))
                MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
        }
        var gun = new Equipment("gun");
        addEquipmentEvent = new AddEquipmentEvent(survivor, gun);
        var maxEquipmentReached = new AddEquipmentMaxEquipmentReachedRule();

        maxEquipmentReached.ExecuteRule(addEquipmentEvent);

        _userInputMock.Verify(x => x.Proceed(), Times.Once());
    }

    [Fact]
    public void ExecuteRule_WhenUserSelectsProceed_EquipmentDropped()
    {
        var equipmentNames = new List<string>()
        {
            "axe",
            "sword",
            "shield",
            "spear",
            "bow"
        };
        var game = new Game(_userInputMock.Object);
        var survivor = new Survivor("Nick", game);
        AddEquipmentEvent addEquipmentEvent;
        var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
        foreach (var name in equipmentNames)
        {
            var equipment = new Equipment(name);
            addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            if (MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent))
                MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
        }
        var gun = new Equipment("gun");
        addEquipmentEvent = new AddEquipmentEvent(survivor, gun);
        var maxEquipmentReached = new AddEquipmentMaxEquipmentReachedRule();

        maxEquipmentReached.ExecuteRule(addEquipmentEvent);

        var EquipmentListAfterDrop = survivor.GetEqupment();

        EquipmentListAfterDrop.Count.ShouldBe(4);
    }

    [Fact]
    public void ExecuteRule_CorrectEquipmentDropped()
    {
        var equipmentNames = new List<string>()
        {
            "sword",
            "shield",
            "spear",
            "bow"
        };
        var game = new Game(_userInputMock.Object);
        var survivor = new Survivor("Nick", game);
        AddEquipmentEvent addEquipmentEvent;
        var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
        foreach (var name in equipmentNames)
        {
            var equipment = new Equipment(name);
            addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
        }
        var axe = new Equipment("axe");
        addEquipmentEvent = new AddEquipmentEvent(survivor, axe);
        MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
        var gun = new Equipment("gun");
        addEquipmentEvent = new AddEquipmentEvent(survivor, gun);
        var maxEquipmentReached = new AddEquipmentMaxEquipmentReachedRule();

        maxEquipmentReached.ExecuteRule(addEquipmentEvent);

        survivor.GetEqupment().ShouldNotContain(gun);
    }
}
