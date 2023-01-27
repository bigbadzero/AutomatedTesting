namespace RPGCombatKata.ConsoleApp;

public class Character
{
    public Guid Id { get; set; }
    public double Health { get; set; }
    public int Level { get; set; }
    public bool Alive { get; set; }

    public Character()
    {
        Health= 1000;  
        Level= 1;
        Alive = true;
        Id = Guid.NewGuid();
    }
   

    public void Attack(Character character, double incomingDamage)
    {
        double incomingDamageAdjustedForLevel = CalculateIncomingDamage(incomingDamage, character.Level);
        if(Id != character.Id )
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
}
