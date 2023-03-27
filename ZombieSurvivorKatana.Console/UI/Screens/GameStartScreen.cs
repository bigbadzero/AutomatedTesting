using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.SubActionScreens.CreateCharacter;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public class GameStartScreen : Screen, IScreen
{
    public GameStartScreen(Game game) : base(game)
    {
    }

    public void DisplayScreenMessage()
    {
        Console.WriteLine("Welcome to Zombie Survivor Game \nHow many surviviors will be in this game to begin with?");
    }

    public void Execute()
    {
        ClearScreen();
        DisplayScreenMessage();
        var numOfUsers = _game._userInput.GetIntFromUser();
        CreateInitialSurvivors(numOfUsers);
    }

    private void CreateInitialSurvivors(int numOfSurvivors)
    {
        for (int i = 0; i < numOfSurvivors; i++)
        {
            var createSurvivorScreen = new CreateSurvivorScreen(_game);
            createSurvivorScreen.Execute();
        }
    }
}
