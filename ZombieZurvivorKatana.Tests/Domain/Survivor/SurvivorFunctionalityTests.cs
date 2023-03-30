using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieZurvivorKatana.Tests
{
    public class SurvivorFunctionalityTests
    {
        [Fact]
        public void Survivor_RecievesTwoWounds_ActiveIsFalse()
        {
            var survivor = new Survivor("fred");

            survivor.RecieveWound();
            survivor.RecieveWound();

            survivor.Active.ShouldBe(false);
        }

        [Fact]
        public void Survivor_WoundsCannotExceed2()
        {
            var survivor = new Survivor("fred");

            survivor.RecieveWound();
            survivor.RecieveWound();
            survivor.RecieveWound();

            survivor.Wounds.ShouldBe(2);
        }
    }
}
