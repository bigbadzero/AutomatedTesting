namespace RPGCombatKata.Console;

public class Character:ICharacterSkills
{
    public Character()
    {
        Health= 1000;  
        Level= 1;
        Alive = true;
    }
    public int Health { get; set; }
    public int Level { get; set; }
    public bool Alive { get; set; }

    public void Attack(Character character, int incomingDamage)
    {
        if(character.Health < incomingDamage)
        {
            character.Health = 0;
            character.Alive = false;
        }
        if(character.Health > incomingDamage)
        {
            character.Health = character.Health - incomingDamage;
        }
    }

    public void Heal(Character character, int incomingHeal)
    {
        if(character.Alive)
        {
            var health = character.Health + incomingHeal;
            if(health > 1000)
            {
                character.Health = 1000;
            }
            else
            {
                character.Health = health;
            }
        }

    }
}
