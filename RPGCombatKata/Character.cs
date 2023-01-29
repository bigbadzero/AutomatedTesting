using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RPGCombatKata.ConsoleApp;

public abstract class Character:BoardObject
{
    public int Level { get; set; }
    public bool Alive { get; set; }
    public int Range { get; set; }
    public List<string> Factions { get; set; }

    public Character()
    {
        Health= 1000;  
        Level= 1;
        Alive = true;
        
        Factions= new List<string>();
    }

    public  void Attack(BoardObject boardObject, double incomingDamage)
    {
        if (boardObject.Id != Id && RangeCheck(boardObject.Position))
        {
            if(boardObject is Character)
            {
                AttackCharacter((Character)boardObject, incomingDamage);
            }
            else
            {
                boardObject.HandleDamage(incomingDamage);
            }
        }
    }

    protected void AttackCharacter(Character character, double incomingDamage)
    {
        var isAlly = IsAlly(character);
        if (!isAlly)
        {
            double incomingDamageAdjustedForLevel = CalculateIncomingDamage(incomingDamage, character.Level);
            character.HandleDamage(incomingDamageAdjustedForLevel);
        }
    }

    public override void HandleDamage(double incomingDamage)
    {
        if (Health < incomingDamage)
        {
            FatalDamage();
        }
        if (Health > incomingDamage)
        {
            Health = Health - incomingDamage;
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

    public void HealAlly(int incomingHeal, Character target)
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

    

    public override void FatalDamage()
    {
        Alive = false;
        Health= 0;
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
