using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.CreateCharacter;

public class CreateSurvivorScreen : Screen, IScreen
{
    private readonly Survivor? _survivor;
    private string Name { get; set; }
    private bool Created = false;

    public CreateSurvivorScreen(Game game) : base(game) { }
    public CreateSurvivorScreen(Game game, Survivor survivor) : base(game)
    {
        _survivor = survivor;
        _survivor.ActionsPerTurn--;
    }



    public void DisplayScreenMessage()
    {
        Console.WriteLine("Enter the name of the new survivor.");
        Name = _game._userInput.GetNameFromUser();
    }

    public void Execute()
    {
        ClearScreen();
        while (!Created)
        {
            DisplayScreenMessage();
            var surviviorAlreadyExist = _game.SurvivorAlreadyExists(Name);
            if (surviviorAlreadyExist)
                Console.WriteLine($"Survivor with the name {Name} already exists");
            else
            {
                _game.CreateSurvivor(Name);
                Created = true;
            }
        }
    }
}
