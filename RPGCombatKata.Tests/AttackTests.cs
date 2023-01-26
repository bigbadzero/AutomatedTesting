using RPGCombatKata.Console;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCombatKata.Tests
{
    public class AttackTests
    {
        [Fact]
        public void AttackPerformed()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 500);

            character2.Health.ShouldNotBe(1000);
        }

        [Fact] 
        public void Damage_Calculated_Correctly()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 500);
            character2.Health.ShouldBe(500);
        }

        [Fact]
        public void Health_Calculated_Correctly_Upon_Death()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }

        [Fact]
        public void Death_Triggered()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Alive.ShouldBe(false);
        }

        [Fact]
        public void Health_Does_Not_Drop_Below_0()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attack(character2, 1500);
            character2.Health.ShouldBe(0);
        }
    }
}
