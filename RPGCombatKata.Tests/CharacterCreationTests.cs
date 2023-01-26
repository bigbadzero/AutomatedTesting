using RPGCombatKata.Console;
using Shouldly;

namespace RPGCombatKata.Tests
{
    public class CharacterCreationTests
    {
        [Fact]
        public void Health_Check()
        {
            var newCharacter = new Character();
            newCharacter.Health.ShouldBe(1000);
        }

        [Fact]
        public void Level_Check()
        {
            var newCharacter = new Character();
            newCharacter.Level.ShouldBe(1);
        }

        [Fact]
        public void Alive_Check()
        {
            var newCharacter = new Character();
            newCharacter.Alive = true;
        }


    }
}