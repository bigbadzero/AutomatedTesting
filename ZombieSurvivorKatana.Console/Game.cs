namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public List<Survivor> Survivors { get; set; }
    public readonly IUserInput _userInput;
    public Game(IUserInput userInput)
    {
        Survivors = new List<Survivor>();
        _userInput = userInput;
        StartGame();
    }

    public void CreateSurvivor(string name)
    {
        var characterCreated = false;
        while(!characterCreated)
        {
            var doesSurviviorAlreadyExist = Survivors.Any(x => x.Name == name);
            if (doesSurviviorAlreadyExist)
            {
                Console.WriteLine($"Survivor with the name {name} already exists");
                Console.WriteLine("Please try a different name");
            }
            else
            {
                var Survivor = new Survivor(name, this);
                Survivors.Add(Survivor);
                Console.WriteLine($"Survivor {Survivor.Name} created");
                characterCreated= true;
            }
        }

    }

    public void CheckGameStatus()
    {
        if (Survivors.All(x => x.Active == false))
            Console.WriteLine("Game Over");
        
    }

    private void StartGame()
    {
        Console.WriteLine("Welcome to Zombie Survivor Game");
        Console.WriteLine("How many surviviors will be in this game to begin with?");
        var numOfSurvivors = _userInput.GetIntFromUser();

        for (int i = 1; i < numOfSurvivors; i++)
        {
            Console.WriteLine($"Enter the name for Survivior #{i}");
            var name = _userInput.GetNameFromUser();
            CreateSurvivor(name);
        }
    }

    private void PlayGame()
    {
        foreach (var survivor in Survivors)
        {
            if (survivor.Active)
            {
                Console.WriteLine($"{survivor.Name} has {survivor.ActionsPerTurn} actions left");
            }
           
        }
    }
}
