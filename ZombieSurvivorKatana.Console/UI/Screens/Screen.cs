namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens;

public abstract class Screen
{
    protected IUserInput _userInput;

    public Screen( IUserInput userInput)
    {
        _userInput = userInput;
    }

    protected void ClearScreen()
    {
        Console.Clear();
    }
}
