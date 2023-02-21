namespace ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

public class InHandEvent
{
    public Survivor Survivor;
    public IUserInput UserInput;
    public readonly int IndexOfEquipmentToBeInHand;

    public InHandEvent(Survivor survivor, IUserInput userInput, int indexOfEquipmentToBeInHand)
    {
        Survivor = survivor;
        UserInput = userInput;
        IndexOfEquipmentToBeInHand = indexOfEquipmentToBeInHand;
    }
}