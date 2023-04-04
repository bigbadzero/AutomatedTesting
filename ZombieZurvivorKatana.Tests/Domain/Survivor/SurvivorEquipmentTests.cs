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
            var survivor = new Survivor("Nick");
            var equipment = new Equipment("Gun");

            survivor.AddEquipment(equipment);
            var survivorsEquipment = survivor.Equipment;

            survivorsEquipment.ShouldContain(equipment);
        }

        [Fact]
        public void SurvivorEquipment_CanBeRemoved()
        {
            var survivor = new Survivor("Nick");
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);
            survivor.DropEquipment(gun);

            var equipment = survivor.Equipment;
            equipment.ShouldNotContain(gun);
        }

        [Fact]
        public void SurvivorEquipment_MaximumEquipmentShouldBe5()
        {
            var survivor = new Survivor("Nick");

            survivor.MaxEquipment.ShouldBe(5);

        }
    }
}
