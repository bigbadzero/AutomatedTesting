using Serilog;
using System.Xml.Linq;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public readonly IUserInput _userInput;
    private bool _gameOver { get; set; }
    public bool GameOver => _gameOver;
    private List<Survivor> _survivors = new List<Survivor>();
    public IReadOnlyList<Survivor> Survivors => _survivors.AsReadOnly();
    private Level _level { get; set; }
    public Level Level { get { return _level; } }
    private Serilog.Core.Logger Logger { get; set; }

    public Game(IUserInput userInput)
    {
        _userInput = userInput;
        _gameOver = false;
        _level = Level.Blue;
        Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("G:\\projects\\AutomatedTesting\\ZombieSurvivorKatana.Console\\logs.txt")
            .CreateLogger();
        Logger.Information($"Zombie Survivor Game Started {DateTime.Now}");
    }

    public void CreateSurvivor(string name)
    {
        var surviviorAlreadyExist = SurvivorAlreadyExists(name);
        if (surviviorAlreadyExist)
        {
            Console.WriteLine($"Survivor with the name {name} already exists");
        }
        else
        {
            var survivor = new Survivor(name);
            survivor.Subscribe(HandleSurvivorEvent);
            _survivors.Add(survivor);
            HandleSurvivorEvent(new SurvivorCreatedEvent(survivor));
        }
    }

    public void PlayGame()
    {
        var gameStartScreen = new GameStartScreen(this);
        gameStartScreen.Execute();
        while (!_gameOver)
        {
            ResetActionsPerTurn();
            foreach (var survivor in _survivors)
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
        Logger.Information(@event.EventDiscription);
        if (@event is SurvivorDeathEvent)
        {
            if (_survivors.All(x => x.Active == false))
            {
                _gameOver = true;
                Console.WriteLine("All survivors are dead. Thanks for playing");
            }
        }
        if (@event is SurvivorLevelUpEvent)
        {
            var currentLevel = (int)Level;
            var highestLevel = 0;
            foreach (var survivor in _survivors)
            {
                var level = (int)survivor.Level;
                if (level > highestLevel)
                    highestLevel = level;
            }
            if (highestLevel > currentLevel)
            {
                _level = (Level)Enum.ToObject(typeof(Level), highestLevel);
                Logger.Information($"The Game has leveled up to {Level}!!");
            }
        }

    }

    public bool SurvivorAlreadyExists(string name)
    {
        var exists = _survivors.Any(x => x.Name == name);
        return exists;
    }

    private void ResetActionsPerTurn()
    {
        foreach (var survivor in _survivors)
            survivor.ResetActionsPerTurn();
    }
}
