using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public abstract class SurvivorScreen : Screen
{
    protected Survivor _survivor;

    protected SurvivorScreen(IUserInput userInput, Survivor survivor) : base(userInput)
    {
        _survivor = survivor;
    }
}
