using Shouldly;
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
        public void Survivior_CurrentMaximumEquipmentReduced_AfterRecievingWound()
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
            for (int i = 0; i < 7; i++)
                survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Yellow);
        }

        [Fact]
        public void Survivor_LevelsUpToOrange_AfterMeetingLevelUpCriteria()
        {
            var survivor = new Survivor("fred");

            //19 times
            for (int i = 0; i < 19; i++)
                survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Orange);
        }

        [Fact]
        public void Survivor_LevelsUpToRed_AfterMeetingLevelUpCriteria()
        {
            var survivor = new Survivor("fred");

            //43 times
            for (int i = 0; i < 43; i++)
                survivor.GainExperience();

            survivor.Level.ShouldBe(Level.Red);
        }

        [Fact]
        public void Survivor_GainsYellowSkill_AfterGaining7Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 7; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Yellow).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Yellow);
            list.Count.ShouldBe(1);
        }
        [Fact]
        public void Survivor_GainsOrangeSkill_AfterGaining19Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 19; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Orange).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Orange);
            list.Count.ShouldBe(1);
        }

        [Fact]
        public void Survivor_GainsOrangeSkill_AfterGaining61Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 61; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Orange).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Orange);
            list.Count.ShouldBe(2);
        }

        [Fact]
        public void Survivor_GainsOrangeSkill_AfterGaining104Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 104; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Orange).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Orange);
            list.Count.ShouldBe(3);
        }

        [Fact]
        public void Survivor_GainsRedSkill_AfterGaining43Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 43; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Red).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Red);
            list.Count.ShouldBe(1);
        }

        [Fact]
        public void Survivor_GainsRedSkill_AfterGaining86Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 86; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Red).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Red);
            list.Count.ShouldBe(2);
        }

        [Fact]
        public void Survivor_GainsRedSkill_AfterGaining129Exp()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 129; i++)
                survivor.GainExperience();
            var list = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Red).ToList();

            list.ShouldNotBeEmpty();
            list.ShouldAllBe(x => x.Level == Level.Red);
            list.Count.ShouldBe(3);
        }

        [Fact]
        public void Survivor_HasCorrectSkills_AfterMaxPointsAcquired()
        {
            var survivor = new Survivor("fred");
            for (int i = 0; i < 129; i++)
                survivor.GainExperience();
            var yellowSkills = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Yellow).ToList();
            var orangeSkills = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Orange).ToList();
            var redSkills = survivor.SkillTree.UnlockedSkills.Where(x => x.Level == Level.Red).ToList();

            yellowSkills.Count.ShouldBe(1);
            orangeSkills.Count.ShouldBe(3);
            redSkills.Count.ShouldBe(3);
            survivor.SkillTree.UnlockedSkills.Count().ShouldBe(7);
        }
    }
}
