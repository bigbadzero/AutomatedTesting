using RPGCombatKata.ConsoleApp;
using Shouldly;

namespace RPGCombatKata.Tests
{
    public class CharacterCreationTests
    {
        [Fact]
        public void CharacterCreation_HasExpectedHealth()
        {
            var newCharacter = new Character();
            newCharacter.Health.ShouldBe(1000);
        }

        [Fact]
        public void HealthCreation_HasExpectedLevel()
        {
            var newCharacter = new Character();
            newCharacter.Level.ShouldBe(1);
        }

        [Fact]
        public void CharacterCreation_IsAlive()
        {
            var newCharacter = new Character();
            newCharacter.Alive = true;
        }

        [Fact]
        public void CharacterCreation_GeneratesUniqueIds()
        {
            var newCharacter1 = new Character();
            var newCharacter2 = new Character();

            newCharacter1.Id.ShouldNotBe(newCharacter2.Id);
        }


    }
}