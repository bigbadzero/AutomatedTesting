
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums.SubScreenActions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

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
                    //Console.WriteLine($"\n{survivor.Name} has {survivor.ActionsPerTurn} actions left");
                    //var gameActionChoosen = actionScreen.GetAction(_userInput, survivor);
                    //var subscreen = ISubActionScreenFactory.GetSubActionScreen(gameActionChoosen);
                    //var subScreenAction = subscreen.GetAction(survivor, this);
                    //var iAction = subscreen.GetIAction(subScreenAction);
                    //iAction.PerformAction(survivor, this);
                    //survivorsHandler.SurvivorStatus(survivor);
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
