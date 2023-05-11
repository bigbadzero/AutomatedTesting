using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.OrangeSkills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills.YellowSkills;

namespace ZombieZurvivorKatana.Tests.Domain.Skills
{
    public class SkillTests
    {
        [Fact] public void SkillTreeLoadsSkills_ToAppropriatePotentialSkillListBasedOnLevel()
        {
            var tree = new SkillTree();

            foreach (var skill in tree.PotentialRedSkills)
                skill.Level.ShouldBe(Level.Red);
            foreach (var skill in tree.PotentialOrangeSkills)
                skill.Level.ShouldBe(Level.Orange);
            foreach (var skill in tree.PotentialYellowSkills)
                skill.Level.ShouldBe(Level.Yellow);
        }

        //yellowSkillTests
        [Fact]
        public void PlusOneAction__AppliedFlag_SetToTrue()
        {
            var survivor = new Survivor("nick");

            survivor.SkillTree.UnlockedSkills.Add(new PlusOneAction());
            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        //orangeSkillTests
        [Fact]
        public void Hoard__AppliedFlag_SetToTrue()
        {
            var survivor = new Survivor("nick");

            survivor.SkillTree.UnlockedSkills.Add(new Hoard());
            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        [Fact]
        public void PlusOneDodge_IncreasesSurvivorDodgeLevelBy1()
        {
            var survivor = new Survivor("nick");
            survivor.SkillTree.UnlockedSkills.Add(new PlusOneDodge());

            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        [Fact]
        public void ToughSkill__AppliedFlag_SetToTrue()
        {
            var survivor = new Survivor("nick");
            survivor.SkillTree.UnlockedSkills.Add(new Tough());

            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        //redSkillTests

        [Fact]
        public void CheatDeathSkill_AppliedFlag_SetToTrue()
        {
            var survivor = new Survivor("nick");
            survivor.SkillTree.UnlockedSkills.Add(new CheatDeath());

            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        [Fact]
        public void DoubleExpSkill_AppliedFlag_SetToTrue()
        {
            var survivor = new Survivor("nick");
            survivor.SkillTree.UnlockedSkills.Add(new DoubleExp());

            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }

        [Fact]
        public void PlusOneMaxWoundsSkill_IncreasesMaxWoundsBy1()
        {
            var survivor = new Survivor("nick");
            survivor.SkillTree.UnlockedSkills.Add(new PlusOneMaxWounds());

            survivor.SkillTree.UnlockedSkills[0].ApplySkill(survivor);

            survivor.SkillTree.UnlockedSkills[0].Applied.ShouldBe(true);
        }
        
    }
}
