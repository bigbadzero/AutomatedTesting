using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieZurvivorKatana.Tests.Mocks;

namespace ZombieZurvivorKatana.Tests
{
    public class SurvivorCreationTests
    {
        public readonly IUserInput _userInput;
        public SurvivorCreationTests()
        {
            _userInput = IUserInputMock.GetBaseMockUserInput().Object;
        }

        [Fact]
        public void SurvivorCreated_WithName()
        {
            var game = new Game(_userInput);
            var name = "Nick";

            var survivor = new Survivor(name, game);

            survivor.Name.ShouldNotBeNullOrEmpty();
            survivor.Name.ShouldBe(name);
        }

        [Fact]
        public void SurvivorCreated_With0Wounds()
        {
            var game = new Game(_userInput);
            var name = "Nick";

            var survivor = new Survivor(name, game);

            survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void SurvivorCreated_WithAbilityToPerform_3ActionsPerTurn()
        {
            var game = new Game(_userInput);
            var name = "Nick";

            var survivor = new Survivor(name, game);

            survivor.ActionsPerTurn.ShouldBe(3);
        }
    }
}
