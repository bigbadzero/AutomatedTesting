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
            var survivor = new Survivor(name, game);
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
            var survivor = new Survivor(name, game);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);
            survivor.DropEquipment(gun);

            var equipment = survivor.GetEqupment();
            equipment.ShouldNotContain(gun);
        }

        [Fact]
        public void SurviviorEquipment_MaxInHandEquipmentNotReachedRule_AddsEquipment()
        {
            var game = new Game(_userInput);
            var name = "Nick";
            var survivor = new Survivor(name, game);
            var gun = new Equipment("Gun");

            survivor.AddEquipment(gun);

            //survivor.SetEquipmentToInHand();

            var currentEquipment = survivor.GetEqupment();
            currentEquipment[0].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
        }

        //[Fact]
        //public void SurviviorEquipment_MaxInHandEquipmentReachedRule_AllowsUserToSwapInHandAndReserveEquipment()
        //{
        //    var game = new Game(_userInput);
        //    var name = "Nick";
        //    var survivor = new Survivor(name, game);
        //    var gun = new Equipment("Gun");
        //    var sword = new Equipment("Sword");
        //    var shield = new Equipment("Shield");
        //    var spear = new Equipment("Spear");
        //    var bow = new Equipment("Bow");

        //    survivor.AddEquipment(gun);
        //    survivor.AddEquipment(sword);
        //    survivor.AddEquipment(shield);
        //    survivor.AddEquipment(spear);
        //    survivor.AddEquipment(bow);
        //    survivor.SetEquipmentToInHand();
        //    survivor.SetEquipmentToInHand();
        //    survivor.SetEquipmentToInHand();


        //    var currentEquipment = survivor.GetEqupment();
        //    currentEquipment[0].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
        //    currentEquipment[2].EquipmentType.ShouldBe(EquipmentTypeEnum.InHand);
        //    currentEquipment[1].EquipmentType.ShouldBe(EquipmentTypeEnum.Reserve);
        //}
    }
}
