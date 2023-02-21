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
    public class SurvivorEquipmentTests
    {
        public readonly IUserInput _userInput;
        public SurvivorEquipmentTests()
        {
            _userInput = IUserInputMock.GetMockUserInput().Object;
        }

        [Fact]
        public void SurvivorEquipment_CanBeAdded()
        {
            var name = "Nick";
            var survivor = new Survivor(name, _userInput);
            var equipment = new Equipment("Gun");


            survivor.AddEquipment(equipment);
            var survivorsEquipment = survivor.GetEqupment();
            survivorsEquipment.ShouldContain(equipment);
        }

        public void SurvivorEquipment_CanBeRemoved()
        {
            var name = "Nick";
            var survivor = new Survivor(name, _userInput);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);
            survivor.DropEquipment();
        }
    }
}
