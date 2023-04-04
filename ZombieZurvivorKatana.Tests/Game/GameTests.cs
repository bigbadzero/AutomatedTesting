using Moq;
using Shouldly;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieZurvivorKatana.Tests.Mocks;

namespace ZombieZurvivorKatana.Tests;

public class GameTests
{
    public readonly Mock<IUserInput> _userInputMock;
    public GameTests()
    {
        _userInputMock = IUserInputMock.GetBaseMockUserInput();
    }

    [Fact]
    public void Game_CreateSurvivor()
    {
        var game = new Game(_userInputMock.Object);
        string jack = "Jack";

        game.CreateSurvivor(jack);

        game.SurvivorAlreadyExists(jack).ShouldBeTrue();
            
    }

    [Fact]
    public void GameStarts_With0Survivors()
    {
        var game = new Game(_userInputMock.Object);

        game.Survivors.Count.ShouldBe(0);
    }

    [Fact]
    public void SurvivorNamesWithinGame_MustBeUnique()
    {
        var game = new Game(_userInputMock.Object);
        game.CreateSurvivor("fred");
        game.CreateSurvivor("fred");

        game.Survivors.Count.ShouldBe(1);
    }

    [Fact]
    public void GameEndsWhen_AllSurvivorsHaveDied()
    {
        var game = new Game(_userInputMock.Object);

        game.CreateSurvivor("fred");
        game.CreateSurvivor("bob");

        game.Survivors[0].RecieveWound();
        game.Survivors[0].RecieveWound();
        game.Survivors[1].RecieveWound();
        game.Survivors[1].RecieveWound();

        game.GameOver.ShouldBeTrue();
    }

    [Fact]
    public void GameDoesNotEndWhen_ASurvivorsIsStillAlive()
    {
        var game = new Game(_userInputMock.Object);

        game.CreateSurvivor("fred");
        game.CreateSurvivor("bob");

        game.Survivors[0].RecieveWound();
        game.Survivors[0].RecieveWound();

        game.GameOver.ShouldBeFalse();
    }

}