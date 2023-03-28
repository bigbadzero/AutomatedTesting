using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    private List<Survivor> Survivors = new List<Survivor>();
    private Level Level { get; set; }

    public Game(IUserInput userInput)
    {
        _userInput = userInput;
        GameOver = false;
        Level = Level.Blue;
    }

    public void CreateSurvivor(string name)
    {
        var survivor = new Survivor(name);
        survivor.Subscribe(HandleSurvivorEvent);
        Survivors.Add(survivor);
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
        Console.WriteLine(@event.EventDiscription);
        if (@event is SurvivorDeathEvent)
        {
            if (Survivors.All(x => x.Active == false))
            {
                GameOver= true;
            }
        }
        if(@event is SurvivorLevelUpEvent)
        {
            var currentLevelIntValue = (int)Level;
            var highestLevel = 0;
            foreach (var survivor in Survivors)
            {
                var level = (int)survivor.Level;
                if(level > highestLevel)
                    highestLevel = level;
            }
            if(highestLevel > currentLevelIntValue)
            {
                Level = (Level)Enum.ToObject(typeof(Level), highestLevel);
                Console.WriteLine($"The Game has leveled up to {Level}!!");
            }
        }
        
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
