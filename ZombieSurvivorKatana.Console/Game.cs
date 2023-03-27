using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    private List<Survivor> Survivors = new List<Survivor>();

    public Game(IUserInput userInput)
    {
        _userInput = userInput;
        GameOver = false;
    }

    public void CreateSurvivor(string name)
    {
        var Survivor = new Survivor(name);
        Survivors.Add(Survivor);
    }

    public void PlayGame()
    {
        var gameStartScreen = new GameStartScreen(this);
        gameStartScreen.Execute();
        while (!GameOver)
        {
            ResetActionsPerTurn();
            foreach (var survivor in Survivors)
            {
                while (survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    var gameActionScreen = new GameActionScreen(this, survivor);
                    gameActionScreen.Execute();
                }
            }
        }
    }

    public void HandleSurvivorEvent(Event @event)
    {
        if (@event is SurvivorDeathEvent)
        {
            if (Survivors.All(x => x.Active == false))
            {

            }
        }
        Console.WriteLine(@event.EventDiscription);
    }

    public bool SurvivorAlreadyExists(string name)
    {
        var exists = Survivors.Any(x => x.Name == name);
        return exists;
    }

    private void ResetActionsPerTurn()
    {
        foreach (var survivor in Survivors)
            survivor.ActionsPerTurn = 3;
    }
}
