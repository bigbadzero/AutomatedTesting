using RPGCombatKata.ConsoleApp;
using Shouldly;

namespace RPGCombatKata.Tests
{
    public class CharacterCreationTests
    {
        [Fact]
        public void CharacterCreation_HasExpectedHealth()
        {
            var newCharacter = new MeleeCharacter();
            newCharacter.Health.ShouldBe(1000);
        }

        [Fact]
        public void HealthCreation_HasExpectedLevel()
        {
            var newCharacter = new MeleeCharacter();
            newCharacter.Level.ShouldBe(1);
        }

        [Fact]
        public void CharacterCreation_IsAlive()
        {
            var newCharacter = new MeleeCharacter();
            newCharacter.Alive = true;
        }

        //iteration 2
        [Fact]
        public void CharacterCreation_GeneratesUniqueIds()
        {
            var newCharacter1 = new MeleeCharacter();
            var newCharacter2 = new MeleeCharacter();

            newCharacter1.Id.ShouldNotBe(newCharacter2.Id);
        }

        //iteration 3
        [Fact]
        public void CharacterCreation_MeleeCharacter()
        {
            var character = new MeleeCharacter();
            character.Range.ShouldBe(2);
            character.Alive.ShouldBeTrue();
            character.Health.ShouldBe(1000);
        }


    }
}