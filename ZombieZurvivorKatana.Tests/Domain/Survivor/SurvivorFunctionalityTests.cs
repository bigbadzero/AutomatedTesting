using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieZurvivorKatana.Tests.Domain
{
    public class SurvivorFunctionalityTests
    {
        [Fact]
        public void SurvivorDiesWhenRecievingTwoWounds()
        {
            var survivor = new Survivor("fred");
            survivor.RecieveWound();
            survivor.RecieveWound();

            survivor.Active.ShouldBe(false);
        }
    }
}
