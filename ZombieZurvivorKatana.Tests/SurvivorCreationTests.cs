using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieZurvivorKatana.Tests.Mocks;

namespace ZombieZurvivorKatana.Tests
{
    public class SurvivorCreationTests
    {
        public readonly IUserInput _userInput;
        public SurvivorCreationTests()
        {
            _userInput = IUserInputMock.GetMockUserInput().Object;
        }

        [Fact]
        public void SurvivorCreated_WithName()
        {
            var name = "Nick";

            var survivor = new Survivor(name, _userInput);

            survivor.Name.ShouldNotBeNullOrEmpty();
            survivor.Name.ShouldBe(name);
        }

        [Fact]
        public void SurvivorCreated_With0Wounds()
        {
            var name = "Nick";

            var survivor = new Survivor(name, _userInput);

            survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void SurvivorCreated_WithAbilityToPerform_3ActionsPerTurn()
        {
            var name = "Nick";

            var survivor = new Survivor(name, _userInput);

            survivor.ActionsPerTurn.ShouldBe(3);
        }
    }
}
