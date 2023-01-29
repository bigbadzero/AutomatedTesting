using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests
{
    public class SurvivorWoundsTests
    {
        [Fact]
        public void SurvivorRecievesWound()
        {
            var nick = new Survivor("Nick");

            nick.RecieveWound();
            nick._wounds.ShouldBe(1);
        }

        [Fact]
        public void SurvivorRecievesMaxWoundsWhichCausesDeath()
        {
            var nick = new Survivor("Nick");

            nick.RecieveWound();
            nick.RecieveWound();

            nick._alive.ShouldBeFalse();
        }

        [Fact]
        public void SurvivorWoundsDoesntIncreasePast2()
        {
            var nick = new Survivor("Nick");

            nick.RecieveWound();
            nick.RecieveWound();
            nick.RecieveWound();
            nick.RecieveWound();

            nick._wounds.ShouldBe(2);
        }
    }
}
