namespace ZombieSurvivorKatana.ConsoleApp;

public interface IUserInput
{
    public int GetIntFromUser();
    public int GetIntFromUserWithRange(int start, int end);
    public bool Proceed();
    public string GetNameFromUser();
}
