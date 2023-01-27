using RPGCombatKata.ConsoleApp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCombatKata.Tests
{
    public class CharacterAttackTests
    {
        //iteration 1
        [Fact]
        public void AttackPerformed()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 500);
            character2.Health.ShouldNotBe(1000);
            
        }


        [Fact] 
        public void CharacterAttacked_RemainingHealthCalculatedCorrectly()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 500);
            character2.Health.ShouldBe(500);
        }

        [Fact]
        public void CharacterAttacked_HealthCalculatedCorrectlyUponDeath()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }

        [Fact]
        public void CharacterAttacked_DeathTriggered()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Alive.ShouldBe(false);
        }

        [Fact]
        public void CharacterAttacked_HealthDoesNotDropBelow0()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }

        //iteration two
        [Fact]
        public void CharacterAttack_CannotAttackItself()
        {
            var character1 = new Character();
            var currentHealth = character1.Health;
            character1.Attack(character1, 500);
            character1.Health.ShouldBe(currentHealth);
        }

        [Fact]
        public void CharacterAttack_TargetLevelFiveOrGreaterThanAttackerDamageCalculatedCorrectly()
        {
            var character1 = new Character();
            var character2 = new Character();
            character2.Level = 6;
            var incomingDamage = 500;
            var expectedHealthAfterAttack = character1.Health - (incomingDamage * .5);
            character1.Attack(character2, incomingDamage);
            character2.Health.ShouldBe(expectedHealthAfterAttack);
        }

        [Fact]
        public void CharacterAttack_TargetLevelFiveOrLessThanAttackerDamageCalculatedCorrectly()
        {
            var character1 = new Character();
            var character2 = new Character();
            character1.Level = 25;
            var incomingDamage = 500;
            var expectedHealthAfterAttack = character1.Health - (incomingDamage + (incomingDamage * .5));
            character1.Attack(character2, incomingDamage);
            character2.Health.ShouldBe(expectedHealthAfterAttack);
        }
    }
}
