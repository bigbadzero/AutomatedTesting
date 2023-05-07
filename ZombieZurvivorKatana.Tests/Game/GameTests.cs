using Moq;
using Shouldly;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieZurvivorKatana.Tests.Mocks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
namespace ZombieZurvivorKatana.Tests;

public class GameTests
{
    public readonly Mock<IUserInput> _baseUserInputMock;
    public GameTests()
    {
        _baseUserInputMock = IUserInputMock.GetBaseMockUserInput();
    }

    [Fact]
    public void Game_CreateSurvivor()
    {
        var game = new Game(_baseUserInputMock.Object);
        string jack = "Jack";

        game.CreateSurvivor(jack);

        game.SurvivorAlreadyExists(jack).ShouldBeTrue();
            
    }

    [Fact]
    public void GameStarts_With0Survivors()
    {
        var game = new Game(_baseUserInputMock.Object);

        game.Survivors.Count.ShouldBe(0);
    }

    [Fact]
    public void SurvivorNamesWithinGame_MustBeUnique()
    {
        var game = new Game(_baseUserInputMock.Object);
        game.CreateSurvivor("fred");
        game.CreateSurvivor("fred");

        game.Survivors.Count.ShouldBe(1);
    }

    [Fact]
    public void GameEndsWhen_AllSurvivorsHaveDied()
    {
        var game = new Game(_baseUserInputMock.Object);

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
        var game = new Game(_baseUserInputMock.Object);

        game.CreateSurvivor("fred");
        game.CreateSurvivor("bob");

        game.Survivors[0].RecieveWound();
        game.Survivors[0].RecieveWound();

        game.GameOver.ShouldBeFalse();
    }

    [Fact]
    public void Game_StartsAt_BlueLevel()
    {

        var game = new Game(_baseUserInputMock.Object);
        game.Level.ShouldBe(Level.Blue);
    }

    [Fact]
    public void Game_LevelsUp_WhenSurvivorLevelsUp()
    {
        var game = new Game(_baseUserInputMock.Object);

        game.CreateSurvivor("fred");

        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();

        game.Level.ShouldBe(Level.Yellow);
    }

    [Fact] 
    public void GamesLevel_EqualsLevel_OfHighestLevelSurvivor()
    {
        var game = new Game(_baseUserInputMock.Object);

        game.CreateSurvivor("fred");
        game.CreateSurvivor("bud");

        //fred gains 6 exp and should be yellow level
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        game.Survivors[0].GainExperience();
        //bud gains 19 exp and should be orange
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();
        game.Survivors[1].GainExperience();

        game.Level.ShouldBe(Level.Orange);
    }

}