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

}