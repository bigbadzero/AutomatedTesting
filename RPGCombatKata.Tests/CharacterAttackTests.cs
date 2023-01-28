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
        public void InRangeAttackPerformedByMeleeCharacter()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;

            character1.Attack(character2, 500);

            character2.Health.ShouldNotBe(1000);
        }

        [Fact]
        public void OutOfRangeAttackPerformedByMeleeCharacter()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 10;

            character1.Attack(character2, 500);

            character2.Health.ShouldBe(1000);
        }

        [Fact]
        public void InRangeAttackPerformedByRangeCharacter()
        {
            var character1 = new MeleeCharacter();
            var character2 = new RangeCharacter();
            character1.Position = 1;
            character2.Position = 21;

            character2.Attack(character1, 500);
            character1.Health.ShouldNotBe(1000);

        }

        [Fact]
        public void OutOfRangeAttackPerformedByRangeCharacter()
        {
            var character1 = new MeleeCharacter();
            var character2 = new RangeCharacter();
            character1.Position = 1;
            character2.Position = 26;

            character2.Attack(character1, 500);
            character1.Health.ShouldBe(1000);

        }


        [Fact] 
        public void CharacterAttacked_RemainingHealthCalculatedCorrectly()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.Attack(character2, 500);
            character2.Health.ShouldBe(500);
        }

        [Fact]
        public void CharacterAttacked_HealthCalculatedCorrectlyUponDeath()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }

        [Fact]
        public void CharacterAttacked_DeathTriggered()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.Attack(character2, 1500);
            character2.Alive.ShouldBe(false);
        }

        [Fact]
        public void CharacterAttacked_HealthDoesNotDropBelow0()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }

        //iteration two
        [Fact]
        public void CharacterAttack_CannotAttackItself()
        {
            var character1 = new MeleeCharacter();
            var currentHealth = character1.Health;
            character1.Attack(character1, 500);
            character1.Health.ShouldBe(currentHealth);
        }

        [Fact]
        public void CharacterAttack_TargetLevelFiveOrGreaterThanAttackerDamageCalculatedCorrectly()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character2.Level = 6;
            var incomingDamage = 500;
            var expectedHealthAfterAttack = character1.Health - (incomingDamage * .5);
            character1.Attack(character2, incomingDamage);
            character2.Health.ShouldBe(expectedHealthAfterAttack);
        }

        [Fact]
        public void CharacterAttack_TargetLevelFiveOrLessThanAttackerDamageCalculatedCorrectly()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.Level = 25;
            var incomingDamage = 500;
            var expectedHealthAfterAttack = character1.Health - (incomingDamage + (incomingDamage * .5));
            character1.Attack(character2, incomingDamage);
            character2.Health.ShouldBe(expectedHealthAfterAttack);
        }
        [Fact]
        public void CharacterAttack_CannotAttackAlly()
        {
            var character1 = new MeleeCharacter();
            var character2 = new MeleeCharacter();
            character1.Position = 1;
            character2.Position = 2;
            character1.JoinFaction("Horde");
            character2.JoinFaction("Horde");
            var currentHealth = character2.Health;
            var incomingDamage = 500;
            character1.Attack(character2, incomingDamage);
            character2.Health.ShouldBe(currentHealth);
        }

    }
}
