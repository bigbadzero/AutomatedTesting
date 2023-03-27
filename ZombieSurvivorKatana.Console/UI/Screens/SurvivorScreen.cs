using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public abstract class SurvivorScreen : Screen
{
    protected Survivor _survivor;

    protected SurvivorScreen(Game game, Survivor survivor) : base(game)
    {
        _survivor = survivor;
    }
}
