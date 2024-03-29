﻿using Shouldly;
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
    public class SurvivorCreationTests
    {
        public readonly IUserInput _userInput;
        public SurvivorCreationTests()
        {
            _userInput = IUserInputMock.GetBaseMockUserInput().Object;
        }

        [Fact]
        public void SurvivorCreated_WithName()
        {
            var name = "Nick";

            var survivor = new Survivor(name);

            survivor.Name.ShouldNotBeNullOrEmpty();
            survivor.Name.ShouldBe(name);
        }

        [Fact]
        public void SurvivorCreated_With0Wounds()
        {
            var name = "Nick";

            var survivor = new Survivor(name);

            survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void SurvivorCreated_WithAbilityToPerform_3ActionsPerTurn()
        {
            var name = "Nick";

            var survivor = new Survivor(name);

            survivor.ActionsPerTurn.ShouldBe(3);
        }

        [Fact]
        public void SurvivorCreated_With0Exp()
        {
            var name = "Nick";

            var survivor = new Survivor(name);
            survivor.Experience.ShouldBe(0);
        }

        [Fact]
        public void SurvivorCreatedWithLevel_SetToBlue()
        {
            var name = "Nick";

            var survivor = new Survivor(name);

            survivor.Level.ShouldBe(Level.Blue);
        }

        [Fact]
        public void SurvivorCreatedWith_SkillTree()
        {
            var name = "Nick";

            var survivor = new Survivor(name);

            survivor.SkillTree.UnlockedSkills.ShouldBeEmpty();
        }
    }
}
