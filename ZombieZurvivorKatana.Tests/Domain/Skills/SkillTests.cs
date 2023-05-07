using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills;

namespace ZombieZurvivorKatana.Tests.Domain.Skills
{
    public class SkillTests
    {
        [Fact] public void SkillTree_LoadsSkills_ToAppropriatePotentialSkillList_BasedOnLevel()
        {
            var tree = new SkillTree();

            foreach (var skill in tree.PotentialRedSkills)
            {
                skill.Level.ShouldBe(Level.Red);
            }
            foreach (var skill in tree.PotentialOrangeSkills)
            {
                skill.Level.ShouldBe(Level.Orange);
            }
            foreach (var skill in tree.PotentialYellowSkills)
            {
                skill.Level.ShouldBe(Level.Yellow);
            }
        }
    }
}
