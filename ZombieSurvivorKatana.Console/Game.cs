using System.Xml.Linq;
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
        Console.WriteLine("Welcome to Zombie Survivor Game \nHow many surviviors will be in this game to begin with?");
        var numOfUsers = _userInput.GetIntFromUser();
        CreateSurvivors(numOfUsers);
        while (!GameOver)
        {
            ResetActionsPerTurn();
            foreach (var survivor in Survivors)
            {
                while (survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    var gameActionScreen = new GameActionScreen(_userInput, survivor);
                    gameActionScreen.Execute();
                }
            }
        }
    }

    public void HandleSurvivorEvent(Event @event)
    {
        if(@event is SurvivorDeathEvent)
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

    private string GetValidSurvivorName(int survivorNum)
    {
        Console.WriteLine($"\nEnter the name for Survivior #{survivorNum}");
        var name = _userInput.GetNameFromUser();
        return name;
    }

    private void CreateSurvivors(int numOfSurvivors)
    {
        for (int i = 0; i < numOfSurvivors; i++)
        {
            var created = false;
            while (!created)
            {
                var name = GetValidSurvivorName(i + 1);
                var surviviorAlreadyExist = SurvivorAlreadyExists(name);
                if (surviviorAlreadyExist)
                    Console.WriteLine($"Survivor with the name {name} already exists");
                else
                {
                    CreateSurvivor(name);
                    created = true;
                }
            }
        }
    }
}
