using RPGCombatKata.ConsoleApp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGCombatKata.Tests
{
    public class BoardObjectTests
    {
        [Fact]
        public void ObjectCreated_With1Health()
        {
            var boardObject = new BoardObject();

            boardObject.Health.ShouldBe(1);
        }

        [Fact]
        public void ObjectCreated_WithSetHealth()
        {
            double health = 500;
            var boardObject = new BoardObject(health);

            boardObject.Health.ShouldBe(health);
        }

        [Fact]
        public void BoardObjectOverridenByChildClass()
        {
            var meleeCharacter = new MeleeCharacter();

            meleeCharacter.Health.ShouldBe(1000);
        }

    }
}
