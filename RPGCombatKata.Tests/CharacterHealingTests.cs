using RPGCombatKata.ConsoleApp;
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

            character1.Health = 500;
            character1.Heal(100);

            character2.Health.ShouldBeGreaterThan(500);
        }


        //badTest
        [Fact]
        public void OverHealingCannotOccur()
        {
            var character1 = new Character();

            character1.Health = 400;
            character1.Heal(5000);
            character1.Health.ShouldBe(1000);
        }

        [Fact]
        public void DeadCharacters_CannotRecieveHealing()
        {
            var character1 = new Character();

            character1.IsDead();
            character1.Heal(500);
            character1.Alive.ShouldBeFalse();
        }
    }
}
