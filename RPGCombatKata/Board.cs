namespace RPGCombatKata.ConsoleApp;

public static class Board
{
    public static List<int> Positions = Enumerable.Range(1, 100).ToList();
    public static List<int> TakenPositions { get; set; } = new List<int>();
}
