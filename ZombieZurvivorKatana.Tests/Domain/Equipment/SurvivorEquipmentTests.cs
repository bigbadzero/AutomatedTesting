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
    public class SurvivorEquipmentTests
    {
        public readonly IUserInput _userInput;
        public SurvivorEquipmentTests()
        {
            _userInput = IUserInputMock.GetBaseMockUserInput().Object;
        }

        [Fact]
        public void SurvivorEquipment_CanBeAdded()
        {
            var game = new Game(_userInput);
            var name = "Nick";
            var survivor = new Survivor(name);
            var equipment = new Equipment("Gun");

            survivor.AddEquipment(equipment);
            var survivorsEquipment = survivor.GetEqupment();

            survivorsEquipment.ShouldContain(equipment);
        }

        [Fact]
        public void SurvivorEquipment_CanBeRemoved()
        {
            var game = new Game(_userInput);
            var name = "Nick";
            var survivor = new Survivor(name);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);
            survivor.DropEquipment(gun);

            var equipment = survivor.GetEqupment();
            equipment.ShouldNotContain(gun);
        }
    }
}
