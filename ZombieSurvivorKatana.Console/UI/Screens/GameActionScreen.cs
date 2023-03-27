using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI.GameActionEnums;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.factories;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public class GameActionScreen : SurvivorScreen, IScreen
{
    public GameActionScreen(IUserInput userInput, Survivor survivor) : base(userInput, survivor) { }
    private ScreenActions action { get; set; }

    public void DisplayScreenMessage()
    {
        Console.WriteLine($"{_survivor.Name} has {_survivor.ActionsPerTurn} actions left\n");
        Console.WriteLine($"What Action Would {_survivor.Name} Like To Perform?");
        var gameActions = Enum.GetNames(typeof(ScreenActions));
        for (int i = 0; i < gameActions.Length; i++)
            Console.WriteLine($"{i + 1} {gameActions[i]}");
        var gameActionIndex = _userInput.GetIntFromUserWithRange(1, gameActions.Length);
        action = (ScreenActions)gameActionIndex;
    }

    public void Execute()
    {
        DisplayScreenMessage();
        var survivorScreen = IScreenFactory.GetScreen(action, _userInput, _survivor);
        survivorScreen.Execute();
    }
}
