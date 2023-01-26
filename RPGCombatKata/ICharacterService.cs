using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCombatKata.Console
{
    public interface ICharacterSkills
    {
        public void Attack(Character character, int incomingDamage);
        public void Heal(Character character, int incomingHeal);  
    }
}
