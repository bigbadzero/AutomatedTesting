using RPGCombatKata.Console;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCombatKata.Tests
{
    public class CharacterHealingTests
    {
        [Fact]
        public void Healing_Occurred()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 500);
            character1.Heal(character2, 100);

            character2.Health.ShouldBeGreaterThan(500);
        }

        [Fact]
        public void CharacterRecivingHealing_OverHealingCannotOccur()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Heal(character2, 500);
            character2.Health.ShouldBe(1000);
        }

        [Fact]
        public void DeadCharacters_CannotRecieveHealing()
        {
            var character1 = new Character();
            var character2 = new Character();

            character2.Alive = false;
            character2.Health = 0;
            character1.Heal(character2, 500);
            character2.Health.ShouldBe(0);
        }
    }
}
