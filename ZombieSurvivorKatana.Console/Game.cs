namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public List<Survivor> Survivors { get; set; }
    private readonly IUserInput _userInput;
    public Game(IUserInput userInput)
    {
        Survivors = new List<Survivor>();
        _userInput = userInput;
    }

    public void CreateSurvivor(string name)
    {
        var doesSurviviorAlreadyExist = Survivors.Any(x => x.Name == name);
        if (doesSurviviorAlreadyExist)
            Console.WriteLine($"Survivor with the name {name} already exists");
        else
        {
            var Survivor = new Survivor(name, _userInput);
            Survivors.Add(Survivor);
            Console.WriteLine($"Survivor {Survivor.Name} created");
        }
    }
}
