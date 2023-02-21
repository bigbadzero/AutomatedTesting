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

        [Fact]
        public void SurvivorEquipment_CanBeRemoved()
        {
            var name = "Nick";
            var survivor = new Survivor(name, _userInput);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);
            survivor.DropEquipment(gun);

            var equipment = survivor.GetEqupment();
            equipment.ShouldNotContain(gun);
        }

        [Fact]
        public void SurviviorEquipment_MaxInHandEquipmentNotReachedRule_AddsEquipment()
        {
            var name = "Nick";
            var survivor = new Survivor(name, _userInput);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);

            survivor.SetEquipmentToInHand(0);

            var currentEquipment = survivor.GetEqupment();
            currentEquipment[0].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
        }

        [Fact]
        public void SurviviorEquipment_MaxInHandEquipmentReachedRule_AllowsUserToSwapInHandAndReserveEquipment()
        {
            var name = "Nick";
            var survivor = new Survivor(name, _userInput);
            var gun = new Equipment("Gun");
            var sword = new Equipment("Sword");
            var shield = new Equipment("Shield");
            var spear = new Equipment("Spear");
            var bow = new Equipment("Bow");

            survivor.AddEquipment(gun);
            survivor.AddEquipment(sword);
            survivor.AddEquipment(shield);
            survivor.AddEquipment(spear);
            survivor.AddEquipment(bow);
            survivor.SetEquipmentToInHand(0);
            survivor.SetEquipmentToInHand(1);
            survivor.SetEquipmentToInHand(2);

            var currentEquipment = survivor.GetEqupment();
            currentEquipment[0].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
            currentEquipment[2].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
            currentEquipment[1].EquipmentType.ShouldBe(EquipmentTypeEnum.Reserve);
        }
    }
}
