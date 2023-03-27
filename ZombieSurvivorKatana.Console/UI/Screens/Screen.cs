namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public abstract class Screen
{
    protected Game _game;

    public Screen(Game game)
    {
        _game= game;
    }

    protected void ClearScreen()
    {
        Console.Clear();
    }
}
