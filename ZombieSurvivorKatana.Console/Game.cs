using ZombieSurvivorKatana.ConsoleApp.Actions;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public List<Survivor> Survivors { get; set; }
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    public Game(IUserInput userInput)
    {
        Survivors = new List<Survivor>();
        _userInput = userInput;
        GameOver = false;
        StartGame();
    }

    public void CreateSurvivor(string name)
    {
        var Survivor = new Survivor(name, this);
        Survivors.Add(Survivor);
        Console.WriteLine($"Survivor {Survivor.Name} created");

    }

    public void CheckGameStatus()
    {
        if (Survivors.All(x => x.Active == false))
            GameOver= true;
        
    }

    private void StartGame()
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
                var surviviorAlreadyExist = Survivors.Any(x => x.Name == name);
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
            ResetActionsPerTurn();
            var actionScreen = new GameActionScreen();
            foreach (var survivor in Survivors)
            {
                while(survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    Console.WriteLine($"\n{survivor.Name} has {survivor.ActionsPerTurn} actions left");
                    var gameActionChoosen = actionScreen.GetAction(_userInput, survivor);
                    var subscreen = ISubActionScreenFactory.GetSubActionScreen(gameActionChoosen);
                    var subScreenAction = subscreen.GetSubScreenAction(_userInput, survivor);
                    var iAction = subscreen.GetIAction(subScreenAction);
                    iAction.PerformAction(survivor);
                }
            }
        }
    }

    private void ResetActionsPerTurn()
    {
        foreach (var survivor in Survivors)
        {
            survivor.ActionsPerTurn = 3;
        }
    }

}
