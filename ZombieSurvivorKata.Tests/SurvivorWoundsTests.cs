using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;
using ZombieSurvivorKata.Tests.Mocks;

namespace ZombieSurvivorKata.Tests
{
    public class SurvivorWoundsTests
    {
        public readonly IUserInput _userInput;
        public SurvivorWoundsTests()
        {
            _userInput = MockIUserInput.GetMockUserInput().Object;
        }

        [Fact]
        public void SurvivorRecievesWound()
        {
            var nick = new Survivor("Nick", _userInput);

            nick.RecieveWound();
            nick._wounds.ShouldBe(1);
        }

        [Fact]
        public void SurvivorRecievesMaxWoundsWhichCausesDeath()
        {
            var nick = new Survivor("Nick", _userInput);

            nick.RecieveWound();
            nick.RecieveWound();

            nick._alive.ShouldBeFalse();
        }

        [Fact]
        public void SurvivorWoundsDoesntIncreasePast2()
        {
            var nick = new Survivor("Nick", _userInput);

            nick.RecieveWound();
            nick.RecieveWound();
            nick.RecieveWound();
            nick.RecieveWound();

            nick._wounds.ShouldBe(2);
        }


    }
}
