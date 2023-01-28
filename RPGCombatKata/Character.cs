using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RPGCombatKata.ConsoleApp;

public abstract class Character
{
    public Guid Id { get; set; }
    public double Health { get; set; }
    public int Level { get; set; }
    public bool Alive { get; set; }
    public int Position { get; set; }
    public int Range { get; set; }
    public List<string> Factions { get; set; }

    public Character()
    {
        Health= 1000;  
        Level= 1;
        Alive = true;
        Id = Guid.NewGuid();
        Position = ChooseRandomPosition();
        Factions= new List<string>();
    }

    public  void Attack(Character character, double incomingDamage)
    {
        var isAlly = IsAlly(character);
        var rangeCheck = RangeCheck(character.Position);
        double incomingDamageAdjustedForLevel = CalculateIncomingDamage(incomingDamage, character.Level);
        if (Id != character.Id && rangeCheck && !isAlly)
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

    public void HealSelf(int incomingHeal)
    {
        if (Alive)
        {
            var newHealth = Health + incomingHeal;
            if (newHealth > 1000)
            {
                Health = 1000;
                Console.WriteLine("Healing Recieved");
            }
            else
            {
                Health = newHealth;
                Console.WriteLine("Healing Recieved");
            }
        }
    }

    public void HealAlly(int incomingHeal, Character target )
    {
        var isAlly = IsAlly(target);
        if (Alive && isAlly && target.Alive)
        {
            var newHealth = target.Health + incomingHeal;
            if (newHealth > 1000)
            {
                target.Health = 1000;
                Console.WriteLine("Healing Recieved");
            }
            else
            {
                target.Health = newHealth;
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

    public void JoinFaction(string faction)
    {
        var memberOfFaction = Factions.Contains(faction);
        if (!memberOfFaction)
        {
            Factions.Add(faction);
        }
        else
        {
            Console.WriteLine("Already a member of faction");
        }
    }

    public void LeaveFaction(string faction)
    {
        var memberOfFaction = Factions.Contains(faction);
        if (memberOfFaction)
        {
            Factions.Remove(faction);
        }
        else
        {
            Console.WriteLine("Not a member of faction");
        }
    }


    private double CalculateIncomingDamage(double incomingDamage, int targetLevel)
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

    private bool RangeCheck(int opponentsPosition)
    {
        if (Range >= Math.Abs(Position - opponentsPosition))
        {
            return true;
        }
        else
            return false;
    }

    private bool IsAlly(Character character)
    {
        bool ally = character.Factions.Any(x => Factions.Contains(x));
        return ally;
    }

}
