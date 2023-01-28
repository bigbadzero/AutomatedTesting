using System;
using System.Globalization;

namespace RPGCombatKata.ConsoleApp;

public abstract class Character
{
    public Guid Id { get; set; }
    public double Health { get; set; }
    public int Level { get; set; }
    public bool Alive { get; set; }
    public int Position { get; set; }
    public int Range { get; set; }

    public Character()
    {
        Health= 1000;  
        Level= 1;
        Alive = true;
        Id = Guid.NewGuid();
        Position = ChooseRandomPosition();
    }

    public  void Attack(Character character, double incomingDamage)
    {
        var rangeCheck = RangeCheck(character.Position);
        double incomingDamageAdjustedForLevel = CalculateIncomingDamage(incomingDamage, character.Level);
        if (Id != character.Id && rangeCheck)
        {
            if (character.Health < incomingDamageAdjustedForLevel)
            {
                character.Health = 0;
                character.Alive = false;
            }
            if (character.Health > incomingDamageAdjustedForLevel)
            {
                character.Health = character.Health - incomingDamageAdjustedForLevel;
            }
        }
        else
        {
            Console.WriteLine("You cannot attack yourself");
        }
    }


    public void Heal(int incomingHeal)
    {
        if (Alive)
        {
            var health = Health + incomingHeal;
            if (health > 1000)
            {
                Health = 1000;
                Console.WriteLine("Healing Recieved");
            }
            else
            {
                Health = health;
                Console.WriteLine("Healing Recieved");
            }
        }
    }

    public void IsDead()
    {
        Alive = false;
        Health= 0;
    }

    public void OverridePosition(int newPosition)
    {
        //is position taken
        var available = Board.Positions.Contains(newPosition);
        if(available)
        {
            Board.Positions.Remove(newPosition);
            Board.Positions.Add(Position);
            Position= newPosition;
        }
        else
        {
            Console.WriteLine("Position Not Available");
        }
    }

    protected double CalculateIncomingDamage(double incomingDamage, int targetLevel)
    {
        double incomingDamageAdjustedForLevel;
        if ((targetLevel - Level) >= 5)
        {
            incomingDamageAdjustedForLevel = (incomingDamage * .5);
        }
        else if ((Level - targetLevel) >= 5)
        {
            incomingDamageAdjustedForLevel = incomingDamage + (incomingDamage * .5);
        }
        else
        {
            incomingDamageAdjustedForLevel = incomingDamage;
        }
        return incomingDamageAdjustedForLevel;
    }

    private int ChooseRandomPosition()
    {
        var random = new Random();
        var index = random.Next(Board.Positions.Count);
        var choosenNumber = Board.Positions[index];
        Board.Positions.Remove(choosenNumber);
        return choosenNumber;
    }

    protected bool RangeCheck(int opponentsPosition)
    {
        if (Range >= Math.Abs(Position - opponentsPosition))
        {
            return true;
        }
        else
            return false;
    }

}
