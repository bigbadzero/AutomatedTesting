using Moq.AutoMock;
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
    
    public class SurvivorEquipmentTests
    {
        public readonly IUserInput _userInput;
        public SurvivorEquipmentTests()
        {
            _userInput= MockIUserInput.GetMockUserInput().Object;
        }

        [Fact]
        public void SurvivorEquipment_CanAddEquipment()
        {
            var nick = new Survivor("Nick", _userInput);
            var gun = new Equipment("Gun");

            nick.AddEquipment(gun);

            nick._equipment.ShouldContain(gun);
        }

        [Fact]
        public void SurvivorEquipment_CannotAddEquipmentIfEquipmentIsFull()
        {
            var nick = new Survivor("Nick", _userInput);
            nick._maxEquipmentCount = 1;
            var gun = new Equipment("Gun");
            var sword = new Equipment("Sword");

            nick.AddEquipment(gun);
            nick.AddEquipment(sword);

            nick._equipment.ShouldNotContain(sword);
        }

        [Fact]
        public void SurvivorEquipment_MustDecreaseForEachWound()
        {
            var nick = new Survivor("Nick", _userInput);
            var gun = new Equipment("Gun");
            var sword = new Equipment("Sword");
            var shield = new Equipment("Shield");
            var spear = new Equipment("Spear");
            var bow = new Equipment("Bow");
            nick.AddEquipment(gun);
            nick.AddEquipment(sword);
            nick.AddEquipment(shield);
            nick.AddEquipment(spear);   
            nick.AddEquipment(bow);

            nick.RecieveWound();

            nick._equipment.Count.ShouldBe(4);
        }
    }
}
