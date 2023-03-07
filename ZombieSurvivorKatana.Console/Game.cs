using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game : IObserver<Survivor>
{
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    private IDisposable cancellation;
    private SurvivorsHandler survivorsHandler = new SurvivorsHandler();

    public Game(IUserInput userInput)
    {
        _userInput = userInput;
        GameOver = false;
        cancellation = survivorsHandler.Subscribe(this);
    }

    public void CreateSurvivor(string name)
    {
        survivorsHandler.CreateSurvivor(name);
    }

    public void StartGame()
    {
        var startScreen = new GameStartScreen(this);
        startScreen.Execute();
    }

    public void PlayGame()
    {
        while (!GameOver)
        {
            survivorsHandler.ResetActionsPerTurn();
            foreach (var survivor in survivorsHandler.GetSurvivors())
            {
                while (survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    var gameActionScreen = new GameActionScreen(this, survivor);
                    gameActionScreen.Execute();
                    survivorsHandler.SurvivorStatus(survivor);
                }
            }
        }
    }

    public bool SurvivorAlreadyExists(string name)
    {
        var exists = survivorsHandler.SurvivorAlreadyExists(name);
        return exists;
    }

    public void OnCompleted()
    {
        cancellation.Dispose();
        GameOver = true;
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Survivor survivor)
    {

    }
}
