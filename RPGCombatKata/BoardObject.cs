namespace RPGCombatKata.ConsoleApp;

public class BoardObject
{
    public Guid Id { get; set; }
    public double Health { get; set; }
    public bool Destoryed { get; set; }
    public int Position { get; set; }
    public BoardObject(double health = 1)
    {
        Health = health;
        Position = ChooseRandomPosition();
        Id = Guid.NewGuid();
        Destoryed = false;
    }

    public virtual void FatalDamage()
    {
        Health = 0;
        Destoryed = true;
    }

    public virtual void HandleDamage(double incomingDamage)
    {
        if (Health > incomingDamage)
            Health = Health - incomingDamage;
        else
            FatalDamage();
    }

    public void OverridePosition(int newPosition)
    {
        var available = Board.Positions.Contains(newPosition);
        if (available)
        {
            Board.Positions.Remove(newPosition);
            Board.Positions.Add(Position);
            Position = newPosition;
        }
        else
            Console.WriteLine("Position Not Available");
    }

    protected int ChooseRandomPosition()
    {
        var random = new Random();
        var index = random.Next(Board.Positions.Count);
        var choosenNumber = Board.Positions[index];
        Board.Positions.Remove(choosenNumber);
        return choosenNumber;
    }

}
