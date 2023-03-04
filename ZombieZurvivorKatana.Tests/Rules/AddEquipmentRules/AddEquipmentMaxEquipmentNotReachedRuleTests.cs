using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Rules.AddEquipmentRules;
using ZombieSurvivorKatana.ConsoleApp.UI;
using ZombieSurvivorKatana.ConsoleApp.UI.Screens.contracts;
using ZombieZurvivorKatana.Tests.Mocks;

namespace ZombieZurvivorKatana.Tests.Rules.AddEquipmentRules
{
    public class AddEquipmentMaxEquipmentNotReachedRuleTests
    {
        public readonly Mock<IUserInput> _userInputMock;
        public AddEquipmentMaxEquipmentNotReachedRuleTests()
        {
            _userInputMock = IUserInputMock.GetBaseMockUserInput();
        }
        [Fact]
        public void IsRuleApplicable_False()
        {
            var game = new Game(_userInputMock.Object);
            var survivor = new Survivor("Nick", game);
            var equipment = new Equipment("axe");
            var addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
            
            var result = MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent);

            result.ShouldBeTrue();
        }

        [Fact]
        public void IsRuleApplicable_True()
        {
            var equipmentNames = new List<string>()
            {
                "axe",
                "sword",
                "shield",
                "spear",
                "bow"
            };
            var game = new Game(_userInputMock.Object);
            var survivor = new Survivor("Nick", game);
            AddEquipmentEvent addEquipmentEvent;
            var MaxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
            foreach (var name in equipmentNames)
            {
                var equipment = new Equipment(name);
                addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
                if (MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent))
                    MaxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
            }
            var gun = new Equipment("gun");
            addEquipmentEvent = new AddEquipmentEvent(survivor, gun);

            var result = MaxEquipmentNotReached.IsRuleApplicable(addEquipmentEvent);

            result.ShouldBeFalse();
        }

        [Fact]
        public void ExecuteRule_AddsEquipmentToSurvivorsEquipmentList()
        {
            var game = new Game(_userInputMock.Object);
            var survivor = new Survivor("Nick", game);
            var equipment = new Equipment("axe");
            var addEquipmentEvent = new AddEquipmentEvent(survivor, equipment);
            var maxEquipmentNotReached = new AddEquipmentMaxEquipmentNotReachedRule();
            
            maxEquipmentNotReached.ExecuteRule(addEquipmentEvent);
            var equipmentList = survivor.GetEqupment();
            equipmentList.ShouldContain(equipment);
        }
    }
}
