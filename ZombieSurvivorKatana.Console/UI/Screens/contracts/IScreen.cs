namespace ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;

public interface IScreen
{
    public void DisplayScreenMessage();
    public Enum GetAction();
    public void Execute();
}
