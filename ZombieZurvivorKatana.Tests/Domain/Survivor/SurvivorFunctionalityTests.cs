using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieZurvivorKatana.Tests
{
    public class SurvivorFunctionalityTests
    {
        [Fact]
        public void Survivor_RecievesTwoWounds_ActiveIsFalse()
        {
            var survivor = new Survivor("fred");

            survivor.RecieveWound();
            survivor.RecieveWound();

            survivor.Active.ShouldBe(false);
        }

        [Fact]
        public void Survivor_WoundsCannotExceed2()
        {
            var survivor = new Survivor("fred");

            survivor.RecieveWound();
            survivor.RecieveWound();
            survivor.RecieveWound();

            survivor.Wounds.ShouldBe(2);
        }

        [Fact]
        public void Survivior_MaximumEquipmentReduced_AfterRecievingWound()
        {
            var survivor = new Survivor("fred");

            survivor.RecieveWound();

            survivor.MaxEquipment.ShouldBe(4);
        }

        [Fact]
        public void Survivior_EquipmentGreaterThanCapacity_CausesGearToBeDiscarded()
        {
            var survivor = new Survivor("fred");
            var axe = new Equipment("axe");
            var sword = new Equipment("sword");
            var shield = new Equipment("shield");
            var gun = new Equipment("gun");
            var spear = new Equipment("spear");
            survivor.AddEquipment(axe);
            survivor.AddEquipment(sword);
            survivor.AddEquipment(shield);
            survivor.ResetActionsPerTurn();
            survivor.AddEquipment(gun);
            survivor.AddEquipment(spear);
            survivor.ResetActionsPerTurn();

            survivor.RecieveWound();

            survivor.Equipment.Count.ShouldBe(4);

        }

        [Fact]
        public void Survivor_LevelsUpToYellow_AfterMeetingLevelUpCriteria()
        {
            var survivor = new Survivor("fred");

            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Yellow);
        }

        [Fact]
        public void Survivor_LevelsUpToOrange_AfterMeetingLevelUpCriteria()
        {
            var survivor = new Survivor("fred");

            //19 times
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Orange);
        }

        [Fact]
        public void Survivor_LevelsUpToRed_AfterMeetingLevelUpCriteria()
        {
            var survivor = new Survivor("fred");

            //43 times
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();
            survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Red);
        }
    }
}
