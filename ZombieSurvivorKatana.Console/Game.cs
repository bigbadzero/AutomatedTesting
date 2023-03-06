
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game: IObserver<Survivor>
{
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    private IDisposable cancellation;
    private SurvivorsHandler survivorsHandler = new SurvivorsHandler();

    public Game(IUserInput userInput)
    {
        _userInput = userInput;
        GameOver = false;
        cancellation =  survivorsHandler.Subscribe(this);
    }

    public void CreateSurvivor(string name)
    {
        survivorsHandler.CreateSurvivor(name);
    }


    public void StartGame()
    {
        var startScreen = new GameStartScreen();
        startScreen.DisplayStartMessage();
        var numOfSurvivors = startScreen.GetNumberOfUsers(_userInput);

        for (int i = 0; i < numOfSurvivors; i++)
        {
            var created = false;
            while (!created)
            {
                var name = startScreen.GetValidSurvivorName(_userInput, i + 1);
                var surviviorAlreadyExist = survivorsHandler.SurvivorAlreadyExists(name);
                if (surviviorAlreadyExist)
                    Console.WriteLine($"Survivor with the name {name} already exists");
                else
                {
                    CreateSurvivor(name);
                    created = true;
                }
            }
        }
        PlayGame();
    }

    private void PlayGame()
    {
        while(!GameOver)
        {
            survivorsHandler.ResetActionsPerTurn();
            var actionScreen = new GameActionScreen();
            foreach (var survivor in survivorsHandler.GetSurvivors())
            {
                while(survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    Console.WriteLine($"\n{survivor.Name} has {survivor.ActionsPerTurn} actions left");
                    var gameActionChoosen = actionScreen.GetAction(_userInput, survivor);
                    var subscreen = ISubActionScreenFactory.GetSubActionScreen(gameActionChoosen);
                    var subScreenAction = subscreen.GetSubScreenAction(survivor, this);
                    var iAction = subscreen.GetIAction(subScreenAction);
                    iAction.PerformAction(survivor, this);
                    survivorsHandler.SurvivorStatus(survivor);
                }
            }
        }
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
